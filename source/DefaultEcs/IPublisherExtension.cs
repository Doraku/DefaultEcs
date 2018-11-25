using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DefaultEcs.Technical.Helper;

namespace DefaultEcs
{    /// <summary>
     /// Specifies that the method should be automatically subscribed when its parent type or instance is called with <see cref="IPublisherExtension"/>.
     /// The decorated method should be of the type <see cref="SubscribeAction{T}"/>.
     /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class SubscribeAttribute : Attribute
    { }

    /// <summary>
    /// Provides set of static methods to automatically subscribe <see cref="SubscribeAction{T}"/> methods marked with the <see cref="SubscribeAttribute"/> on a <see cref="IPublisher"/>instance.
    /// </summary>
    public static class IPublisherExtension
    {
        #region Fields

        private static readonly MethodInfo _subscribeMethod = typeof(IPublisher).GetTypeInfo().GetDeclaredMethod(nameof(IPublisher.Subscribe));

        #endregion

        #region Methods

        private static IDisposable Subscribe(IPublisher publisher, Type type, object target)
        {
            List<IDisposable> subscriptions = new List<IDisposable>();

            try
            {
                while (type != null)
                {

                    foreach (MethodInfo method in type.GetTypeInfo().DeclaredMethods
                        .Where(m => m.GetCustomAttribute<SubscribeAttribute>(true) != null)
                        .Where(m => m.IsStatic || target != null))
                    {
                        ParameterInfo[] parameters = method.GetParameters();

                        if (parameters.Length != 1
                            || !parameters[0].ParameterType.IsByRef
                            || method.ReturnType != typeof(void))
                        {
                            throw new NotSupportedException($"Can't apply {nameof(SubscribeAttribute)} to \"{method.Name}\": method is not of type {nameof(SubscribeAction<object>)}.");
                        }

                        Type argType = parameters[0].ParameterType.GetElementType();
                        subscriptions.Add((IDisposable)_subscribeMethod.MakeGenericMethod(argType).Invoke(
                            publisher,
                            new object[]
                            {
                            method.IsStatic
                                ? method.CreateDelegate(typeof(SubscribeAction<>).MakeGenericType(argType))
                                : method.CreateDelegate(typeof(SubscribeAction<>).MakeGenericType(argType), target)
                            }));
                    }

                    type = type.GetTypeInfo().BaseType;
                }
            }
            catch
            {
                foreach (IDisposable disposable in subscriptions)
                {
                    disposable.Dispose();
                }

                throw;
            }

            return subscriptions.Count > 1 ? subscriptions.Merge() : subscriptions.FirstOrDefault();
        }

        /// <summary>
        /// Subscribes automatically methods of a Type marked with the <see cref="SubscribeAttribute"/> on an <see cref="IPublisher"/> instance.
        /// </summary>
        /// <param name="publisher">The <see cref="IPublisher"/> instance.</param>
        /// <param name="type">The type.</param>
        /// <returns>A <see cref="IDisposable"/> to unregister.</returns>
        /// <exception cref="ArgumentNullException">publisher or type is null.</exception>
        /// <exception cref="NotSupportedException"><see cref="SubscribeAttribute"/> is used on an uncompatible method of the instance.</exception>
        public static IDisposable Subscribe(this IPublisher publisher, Type type)
        {
            return Subscribe(
                publisher ?? throw new ArgumentNullException(nameof(publisher)),
                type ?? throw new ArgumentNullException(nameof(type)),
                null);
        }

        /// <summary>
        /// Subscribes automatically methods of a Type marked with the <see cref="SubscribeAttribute"/> on an <see cref="IPublisher"/> instance.
        /// </summary>
        /// <typeparam name="T">The Type.</typeparam>
        /// <param name="publisher">The <see cref="IPublisher"/> instance.</param>
        /// <returns>A <see cref="IDisposable"/> to unregister.</returns>
        /// <exception cref="ArgumentNullException">publisher is null.</exception>
        /// <exception cref="NotSupportedException"><see cref="SubscribeAttribute"/> is used on an uncompatible method of the instance.</exception>
        public static IDisposable Subscribe<T>(this IPublisher publisher) => Subscribe(publisher, typeof(T));

        /// <summary>
        /// Subscribes automatically methods of an instance and its Type marked with the <see cref="SubscribeAttribute"/> on an <see cref="IPublisher"/> instance.
        /// </summary>
        /// <typeparam name="T">The Type.</typeparam>
        /// <param name="publisher">The <see cref="IPublisher"/> instance.</param>
        /// <param name="target">The instance.</param>
        /// <returns>A <see cref="IDisposable"/> to unregister.</returns>
        /// <exception cref="ArgumentNullException">publisher or target is null.</exception>
        /// <exception cref="NotSupportedException"><see cref="SubscribeAttribute"/> is used on an uncompatible method of the instance.</exception>
        public static IDisposable Subscribe<T>(this IPublisher publisher, T target)
            where T : class
        {
            return Subscribe(
                publisher ?? throw new ArgumentNullException(nameof(publisher)),
                (target ?? throw new ArgumentNullException(nameof(target))).GetType(),
                target);
        }

        #endregion
    }
}

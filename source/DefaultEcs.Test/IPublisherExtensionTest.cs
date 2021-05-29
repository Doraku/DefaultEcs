using System;
using System.Diagnostics.CodeAnalysis;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class IPublisherExtensionTest
    {
        #region Types

        private sealed class Publisher : IPublisher
        {
            public int SubscribeCount;

            public Delegate Action { get; private set; }

            public IDisposable Subscribe<T>(MessageHandler<T> action)
            {
                Action = action;
                ++SubscribeCount;

                return null;
            }

            public void Publish<T>(in T message)
            { }

            public void Dispose()
            { }
        }

        private sealed class InvalidNumberOfParameter
        {
            [Subscribe]
            [SuppressMessage("Style", "IDE0060:Remove unused parameter")]
            [SuppressMessage("Runtime Error", "DEA0001:SubscribeAttribute used on an invalid method")]
            public static void Method(object _, object __) { }
        }

        private sealed class InvalidReturnType
        {
            [Subscribe]
            [SuppressMessage("Runtime Error", "DEA0001:SubscribeAttribute used on an invalid method")]
            public static object Method(in object _) { return null; }
        }

        private sealed class InvalidByRefParameterType
        {
            [Subscribe]
            [SuppressMessage("Runtime Error", "DEA0001:SubscribeAttribute used on an invalid method")]
            public static void Method(object _) { }
        }

        private sealed class StaticMethod
        {
            [Subscribe]
            public static void Method(in object arg)
            {
                if (arg is null)
                {
                    throw new ArgumentNullException(nameof(arg));
                }
            }
        }

        private class InstanceMethod
        {
            [Subscribe]
            [SuppressMessage("Performance", "CA1822")]
            public void Method(in object _) { }
        }

        private sealed class DerivedClass : InstanceMethod
        { }

        private abstract class AbstractMethod
        {
            [Subscribe]
            public abstract void Method(in object arg);
        }

        private sealed class ImplementClass : AbstractMethod
        {
            public override void Method(in object arg)
            { }

            [Subscribe]
            [SuppressMessage("Performance", "CA1822")]
            public void NewMethod(in int _)
            { }
        }

        private abstract class AbstractNonDecoratedMethod
        {
            public abstract void Method(in object arg);
        }

        private sealed class ImplementNonDecoratedClass : AbstractNonDecoratedMethod
        {
            [Subscribe]
            public override void Method(in object arg)
            { }
        }

        private sealed class ValidAndInvalidDecoratedClass
        {
            public object Arg { get; set; }

            [Subscribe]
            public void Valid(in object arg) => Arg = arg;

            [Subscribe]
            [SuppressMessage("Runtime Error", "DEA0001:SubscribeAttribute used on an invalid method")]
            public object Invalid(in object arg) => Arg = arg;
        }

        #endregion

        #region Tests

        [Fact]
        public void Subscribe_Should_thow_ArgumentNullException_When_publisher_is_null()
        {
            IPublisher publisher = null;

            Check
                .ThatCode(() => publisher.Subscribe<object>())
                .Throws<ArgumentNullException>();
        }

        [Fact]
        public void Subscribe_type_Should_thow_ArgumentNullException_When_type_is_null()
        {
            using IPublisher publisher = new Publisher();

            Check
                .ThatCode(() => publisher.Subscribe(default))
                .Throws<ArgumentNullException>();
        }

        [Fact]
        public void Subscribe_Should_thow_NotSupportedException_When_method_has_invalid_numbers_of_parameter()
        {
            using IPublisher publisher = new Publisher();

            Check
                .ThatCode(() => publisher.Subscribe<InvalidNumberOfParameter>())
                .Throws<NotSupportedException>();
        }

        [Fact]
        public void Subscribe_Should_thow_NotSupportedException_When_method_has_invalid_ByRef_parameter()
        {
            using IPublisher publisher = new Publisher();

            Check
                .ThatCode(() => publisher.Subscribe<InvalidByRefParameterType>())
                .Throws<NotSupportedException>();
        }

        [Fact]
        public void Subscribe_Should_thow_NotSupportedException_When_method_has_a_non_void_return_type()
        {
            using IPublisher publisher = new Publisher();

            Check
                .ThatCode(() => publisher.Subscribe<InvalidReturnType>())
                .Throws<NotSupportedException>();
        }

        [Fact]
        public void Subscribe_Should_call_publisher_Subscribe_on_decorated_static_method()
        {
            using Publisher publisher = new();

            publisher.Subscribe<StaticMethod>();

            Check.That(publisher.Action).IsEqualTo(new MessageHandler<object>(StaticMethod.Method));
        }

        [Fact]
        public void Subscribe_target_Should_thow_ArgumentNullException_When_publisher_is_null()
        {
            IPublisher publisher = null;
            object target = null;

            Check
                .ThatCode(() => publisher.Subscribe(target))
                .Throws<ArgumentNullException>();
        }

        [Fact]
        public void Subscribe_target_Should_thow_ArgumentNullException_When_target_is_null()
        {
            using IPublisher publisher = new Publisher();
            object target = null;

            Check
                .ThatCode(() => publisher.Subscribe(target))
                .Throws<ArgumentNullException>();
        }

        [Fact]
        public void Subscribe_target_Should_call_publisher_Subscribe_on_decorated_instance_method()
        {
            Publisher publisher = new();
            InstanceMethod target = new();

            publisher.Subscribe(target);

            Check.That(publisher.Action).IsEqualTo(new MessageHandler<object>(target.Method));
        }

        [Fact]
        public void Subscribe_target_Should_call_publisher_Subscribe_on_decorated_method_from_base_class()
        {
            Publisher publisher = new();
            DerivedClass target = new();

            publisher.Subscribe(target);

            Check.That(publisher.Action).IsEqualTo(new MessageHandler<object>(target.Method));
        }

        [Fact]
        public void Subscribe_target_Should_call_publisher_Subscribe_on_decorated_abstract_method()
        {
            Publisher publisher = new();
            AbstractMethod target = new ImplementClass();

            publisher.Subscribe(target);

            Check.That(publisher.Action).IsEqualTo(new MessageHandler<object>(target.Method));
        }

        [Fact]
        public void Subscribe_target_Should_call_publisher_Subscribe_on_decorated_overriden_method()
        {
            Publisher publisher = new();
            AbstractNonDecoratedMethod target = new ImplementNonDecoratedClass();

            publisher.Subscribe(target);

            Check.That(publisher.Action).IsEqualTo(new MessageHandler<object>(target.Method));
        }

        [Fact]
        public void Subscribe_target_Should_call_publisher_Subscribe_once_for_each_decorate_method()
        {
            Publisher publisher = new();
            ImplementClass target = new();

            publisher.Subscribe(target);

            Check.That(publisher.SubscribeCount).IsEqualTo(2);
        }

        [Fact]
        public void Subscribe_Should_dispose_subscription_When_error_encountered()
        {
            using IPublisher publisher = new World();

            ValidAndInvalidDecoratedClass item = new();

            Check
                .ThatCode(() => publisher.Subscribe(item))
                .Throws<NotSupportedException>();

            publisher.Publish(new object());

            Check.That(item.Arg).IsNull();
        }

        #endregion
    }
}

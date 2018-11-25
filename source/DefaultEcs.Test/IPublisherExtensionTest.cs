using System;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class IPublisherExtensionTest
    {
        #region Types

        private sealed class Publisher : IPublisher
        {
            public Delegate Action { get; private set; }

            public IDisposable Subscribe<T>(SubscribeAction<T> action)
            {
                Action = action;

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
            public static void Method(object arg1, object arg2) { }
        }

        private sealed class InvalidReturnType
        {
            [Subscribe]
            public static object Method(in object arg1) { return null; }
        }

        private sealed class InvalidByRefParameterType
        {
            [Subscribe]
            public static void Method(object arg1) { }
        }

        private sealed class StaticMethod
        {
            [Subscribe]
            public static void Method(in object arg) { }
        }

        private class InstanceMethod
        {
            [Subscribe]
            public void Method(in object arg) { }
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
        public void Subscribe_Should_thow_NotSupportedException_When_method_has_invalid_numbers_of_parameter()
        {
            IPublisher publisher = new Publisher();
            
            Check
                .ThatCode(() => publisher.Subscribe<InvalidNumberOfParameter>())
                .Throws<NotSupportedException>();
        }

        [Fact]
        public void Subscribe_Should_thow_NotSupportedException_When_method_has_invalid_ByRef_parameter()
        {
            IPublisher publisher = new Publisher();

            Check
                .ThatCode(() => publisher.Subscribe<InvalidByRefParameterType>())
                .Throws<NotSupportedException>();
        }

        [Fact]
        public void Subscribe_Should_thow_NotSupportedException_When_method_has_a_non_void_return_type()
        {
            IPublisher publisher = new Publisher();

            Check
                .ThatCode(() => publisher.Subscribe<InvalidReturnType>())
                .Throws<NotSupportedException>();
        }

        [Fact]
        public void Subscribe_Should_call_publisher_Subscribe_on_decorated_static_method()
        {
            Publisher publisher = new Publisher();

            publisher.Subscribe<StaticMethod>();

            Check.That(publisher.Action).IsEqualTo(new SubscribeAction<object>(StaticMethod.Method));
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
            IPublisher publisher = new Publisher();
            object target = null;

            Check
                .ThatCode(() => publisher.Subscribe(target))
                .Throws<ArgumentNullException>();
        }

        [Fact]
        public void Subscribe_target_Should_call_publisher_Subscribe_on_decorated_instance_method()
        {
            Publisher publisher = new Publisher();
            InstanceMethod target = new InstanceMethod();

            publisher.Subscribe(target);

            Check.That(publisher.Action).IsEqualTo(new SubscribeAction<object>(target.Method));
        }

        [Fact]
        public void Subscribe_target_Should_call_publisher_Subscribe_on_decorated_method_from_base_class()
        {
            Publisher publisher = new Publisher();
            DerivedClass target = new DerivedClass();

            publisher.Subscribe(target);

            Check.That(publisher.Action).IsEqualTo(new SubscribeAction<object>(target.Method));
        }

        [Fact]
        public void Subscribe_target_Should_call_publisher_Subscribe_on_decorated_abstract_method()
        {
            Publisher publisher = new Publisher();
            ImplementClass target = new ImplementClass();

            publisher.Subscribe(target);

            Check.That(publisher.Action).IsEqualTo(new SubscribeAction<object>(target.Method));
        }

        #endregion
    }
}

﻿using System;
using DefaultEcs.Internal.Serialization;
using DefaultEcs.Internal.Serialization.BinarySerializer;
using DefaultEcs.Internal.Serialization.BinarySerializer.ConverterAction;

namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Represents a context used by the <see cref="BinarySerializer"/> to convert types during serialization and deserialization operations.
    /// The context marshalling will not be applied on members of unmanaged type as <see cref="BinarySerializer"/> just past their memory location with no transformation.
    /// </summary>
    public sealed class BinarySerializationContext : IDisposable
    {
        #region Types

        private sealed class MarshalComponentOperation<TIn, TOut> : BinarySerializer.IComponentOperation
        {
            #region Fields

            private readonly Func<TIn, TOut> _converter;

            #endregion

            #region Initialisation

            public MarshalComponentOperation(Func<TIn, TOut> converter)
            {
                _converter = converter;
            }

            #endregion

            #region IOperation

            //public void SetMaxCapacity(World world, int maxCapacity) => world.SetMaxCapacity<TOut>(maxCapacity);

            public void Set(World world, in StreamReaderWrapper reader) => world.Set(_converter(Converter<TIn>.Read(reader)));

            public void Set(in Entity entity, in StreamReaderWrapper reader) => entity.Set(_converter(Converter<TIn>.Read(reader)));

            //public void SetSameAs(in Entity entity, in Entity reference) => entity.SetSameAs<TOut>(reference);

            //public void SetSameAsWorld(in Entity entity) => entity.SetSameAsWorld<TOut>();

            public void SetDisabled(in Entity entity, in StreamReaderWrapper reader)
            {
                Set(entity, reader);
                entity.Disable<TOut>();
            }

            //public void SetDisabledSameAs(in Entity entity, in Entity reference)
            //{
            //    SetSameAs(entity, reference);
            //    entity.Disable<TOut>();
            //}

            //public void SetDisabledSameAsWorld(in Entity entity)
            //{
            //    SetSameAsWorld(entity);
            //    entity.Disable<TOut>();
            //}

            public BinarySerializer.IComponentOperation ApplyContext(BinarySerializationContext context) => this;

            #endregion
        }

        #endregion

        #region Fields

        private readonly int _id;

        internal string TypeMarshalling;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializationContext"/> class.
        /// </summary>
        public BinarySerializationContext()
        {
            _id = SerializationContext.GetId();
        }

        #endregion

        #region Methods

        internal Action<ComponentTypeWriter, int, bool> GetWorldWrite<T>() => _id < SerializationContext<T>.Actions.Length ? SerializationContext<T>.Actions[_id].WorldWrite as Action<ComponentTypeWriter, int, bool> : null;

        internal Action<EntityWriter, T, Entity, bool> GetEntityWrite<T>() => _id < SerializationContext<T>.Actions.Length ? SerializationContext<T>.Actions[_id].EntityWrite as Action<EntityWriter, T, Entity, bool> : null;

        internal WriteAction<T> GetValueWrite<T>() => _id < SerializationContext<T>.Actions.Length ? SerializationContext<T>.Actions[_id].ValueWrite as WriteAction<T> : null;

        internal ReadAction<TOut> GetValueRead<TIn, TOut>() => _id < SerializationContext<TIn>.Actions.Length ? SerializationContext<TIn>.Actions[_id].ValueRead as ReadAction<TOut> : null;

        internal BinarySerializer.IComponentOperation GetComponentOperation<TIn>() => _id < SerializationContext<TIn>.Actions.Length ? SerializationContext<TIn>.Actions[_id].ComponentRead as BinarySerializer.IComponentOperation : null;

        /// <summary>
        /// Adds a convertion between the type <typeparamref name="TIn"/> and the type <typeparamref name="TOut"/> during a serialization operation.
        /// </summary>
        /// <typeparam name="TIn">The type which need to be converted.</typeparam>
        /// <typeparam name="TOut">The resulting type of the conversion.</typeparam>
        /// <param name="converter">The function used for the conversion.</param>
        /// <returns>Returns itself.</returns>
        public BinarySerializationContext Marshal<TIn, TOut>(Func<TIn, TOut> converter)
        {
            if (converter is null)
            {
                SerializationContext<TIn>.SetWriteActions(_id, null, null, null);
            }
            else
            {
                SerializationContext<TIn>.SetWriteActions(
                    _id,
                    new Action<ComponentTypeWriter, int, bool>((writer, maxCapacity, hasComponent) => writer.WriteComponent(maxCapacity, hasComponent, w => converter(w.Get<TIn>()))),
                    new Action<EntityWriter, TIn, Entity, bool>((writer, value, owner, isEnabled) => writer.WriteComponent(converter(value), owner, isEnabled)),
                    new WriteAction<TIn>((in StreamWriterWrapper writer, in TIn value) =>
                    {
                        writer.WriteTypeMarshalling(TypeNames.Get(typeof(TOut)));
                        writer.WriteValue(converter(value));
                    }));
            }

            return this;
        }

        /// <summary>
        /// Adds a convertion between the type <typeparamref name="TIn"/> and the type <typeparamref name="TOut"/> during a deserialization operation.
        /// </summary>
        /// <typeparam name="TIn">The type which need to be converted.</typeparam>
        /// <typeparam name="TOut">The resulting type of the conversion.</typeparam>
        /// <param name="converter">The function used for the conversion.</param>
        /// <returns>Returns itself.</returns>
        public BinarySerializationContext Unmarshal<TIn, TOut>(Func<TIn, TOut> converter)
        {
            if (converter is null)
            {
                SerializationContext<TIn>.SetReadActions(_id, null, null);
            }
            else
            {
                SerializationContext<TIn>.SetReadActions(
                    _id,
                    new MarshalComponentOperation<TIn, TOut>(converter),
                    new ReadAction<TOut>((in StreamReaderWrapper reader) => converter(reader.ReadValue<TIn>())));
            }

            return this;
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases inner resources.
        /// </summary>
        public void Dispose()
        {
            SerializationContext.ReleaseId(_id);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

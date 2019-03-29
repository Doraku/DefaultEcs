namespace DefaultEcs.Command
{
    public readonly ref struct EntityRecord
    {
        private readonly EntityCommandRecorder _recorder;
        private readonly int _offset;

        internal EntityRecord(EntityCommandRecorder recorder, int offset)
        {
            _recorder = recorder;
            _offset = offset;
        }

        public void Enable() => _recorder.Enable(_offset);

        public void Disable() => _recorder.Disable(_offset);

        public void Enable<T>() => _recorder.Enable<T>(_offset);

        public void Disable<T>() => _recorder.Disable<T>(_offset);

        public void Set<T>(in T component = default) => _recorder.Set(_offset, component);

        public void SetSameAs<T>(in EntityRecord reference) => _recorder.SetSameAs<T>(_offset, reference._offset);

        public void Remove<T>() => _recorder.Remove<T>(_offset);

        public void SetAsChildOf(in EntityRecord parent) => _recorder.SetAsChildOf(_offset, parent._offset);

        public void SetAsParentOf(in EntityRecord child) => child.SetAsChildOf(this);

        public void RemoveFromChildrenOf(in EntityRecord parent) => _recorder.RemoveFromChildrenOf(_offset, parent._offset);

        public void RemoveFromParentsOf(in EntityRecord child) => child.RemoveFromChildrenOf(this);

        public void Dispose() => _recorder.Dispose(_offset);
    }
}

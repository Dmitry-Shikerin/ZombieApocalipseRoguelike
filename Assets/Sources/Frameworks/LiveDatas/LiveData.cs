using System;
using System.Collections.Generic;

namespace Sources.Frameworks.LiveDatas
{
    public class LiveData<T> : IDisposable
    {
        private readonly List<Action<T>> _callbacks = new List<Action<T>>();

        private MutableLiveData<T> _liveData;

        public LiveData(MutableLiveData<T> liveData)
        {
            _liveData = liveData;
            _liveData.Changed += OnValueChanged;
            _liveData.Disposing += Dispose;
        }

        public T Value => _liveData.Value;

        public void Observe(Action<T> callback)
        {
            if(_callbacks.Contains(callback))
                return;
            
            _callbacks.Add(callback);
            callback.Invoke(_liveData.Value);
        }

        public void UnObserve(Action<T> callback) => 
            _callbacks.Remove(callback);

        private void OnValueChanged(T value)
        {
            foreach(Action<T> callback in _callbacks)
                callback.Invoke(value);
        }

        public void Dispose()
        {
            _liveData.Disposing -= Dispose;
            _liveData.Changed -= OnValueChanged;

            _callbacks.Clear();
            _liveData = null;
        }
    }
}
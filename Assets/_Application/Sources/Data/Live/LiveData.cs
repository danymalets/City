using System;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.ApplicationCycle;

namespace Sources.Data.Live
{
    public abstract class LiveData<T>
    {
        public event Action<T> Changed = delegate { };

        private T _value;
        
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                Changed(_value);
            }
        }

        public LiveData(T value = default)
        {
            _value = value;
        }
    }

    public class LiveFloat : LiveData<float> { }

    public class LiveString : LiveData<string> { }
}
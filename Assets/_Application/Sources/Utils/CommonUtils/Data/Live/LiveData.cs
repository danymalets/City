using System;

namespace _Application.Sources.Utils.CommonUtils.Data.Live
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
                if (!_value.Equals(value))
                {
                    _value = value;
                    Changed(_value);
                }
            }
        }

        protected LiveData(T value = default)
        {
            _value = value;
        }
    }
}
using System;
using UnityEngine.Assertions;

namespace Sources.Services.UserService
{
    public class Currency
    {
        public long Value { get; private set; }

        public event Action<long> Changed;
        
        public Currency(long value = 0)
        {
            Value = 0;
        }

        public bool TrySpend(long spendValue)
        {
            if (Value >= spendValue)
            {
                Value -= spendValue;
                Changed?.Invoke(Value);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Spend(long spendValue) => 
            Assert.IsTrue(TrySpend(spendValue));

        public void AddCurrency(long value)
        {
            Value += value;
            Changed?.Invoke(Value);
        }
    }
}
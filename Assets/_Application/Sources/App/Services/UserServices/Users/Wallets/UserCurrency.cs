using System;
using UnityEngine.Assertions;

namespace Sources.App.Services.UserServices.Users.Wallets
{
    public class UserCurrency
    {
        public long Value { get; private set; }

        public event Action<long> Changed;
        
        public UserCurrency(long value = 0)
        {
            Value = value;
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
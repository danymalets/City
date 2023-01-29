using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Utilities.Extensions;

namespace Sources.Utilities
{
    public static class DValidate
    {
        public static void AddRequired<T, TEnum>(List<T> list, Func<T, TEnum> getEnum, Action<T, TEnum> setEnum) 
            where T : new()
            where TEnum : Enum
        {
            foreach (TEnum en in GetAllEnums<TEnum>())
            {
                if (list.NoOne(e => en.CompareTo(getEnum(e)) == 0))
                {
                    T item = new T();
                    setEnum(item, en);
                    list.Add(item);
                }
            }
        }
        
        public static void RemoveDuplicates<T, TEnum>(List<T> list, Func<T, TEnum> getEnum) 
            where T : new()
            where TEnum : Enum
        {
            // List<T> itemsToRemove = new();
            // for (int i = 0; i < list.Count; i++)
            // {
            //     for (int j = 0; j < i; j++)
            //     {
            //         if (list.)
            //     }
            // }
        }

        public static IEnumerable<TEnum> GetAllEnums<TEnum>() where TEnum : Enum => 
            Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
    }
}
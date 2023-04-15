using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Utils.CommonUtils.Extensions;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class DValidate
    {
        public static void OptimizeEnumsData<T, TEnum>(List<T> list, Func<T, TEnum> getEnum, Func<TEnum, T> creatEnum, TEnum[] except = null)
            where TEnum : Enum
        {
            AddRequired(list, getEnum, creatEnum, except);
            RemoveDuplicates(list, getEnum);
            Sort(list, getEnum);
        }
        
        private static void AddRequired<T, TEnum>(List<T> list, Func<T, TEnum> getEnum, Func<TEnum, T> createEnum, TEnum[] except = null) 
            where TEnum : Enum
        {
            except ??= Array.Empty<TEnum>();

            foreach (TEnum en in DEnums.GetAllEnums<TEnum>())
            {
                if (list.NoOne(e => en.Equals(getEnum(e))) && 
                    except.NoOne(e => en.Equals(e)))
                {
                    list.Add(createEnum(en));
                }
            }
        }
        
        private static void RemoveDuplicates<T, TEnum>(List<T> list, Func<T, TEnum> getEnum) 
            where TEnum : Enum
        {
            List<T> itemsToRemove = new();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (getEnum(list[i]).Equals(getEnum(list[j])))
                    {
                        itemsToRemove.Add(list[j]);
                    }
                }
            }

            foreach (T itemToRemove in itemsToRemove) 
                list.Remove(itemToRemove);
        }

        private static void Sort<T, TEnum>(List<T> list, Func<T, TEnum> getEnum) => 
            list = list.OrderBy(getEnum).ToList();
    }
}
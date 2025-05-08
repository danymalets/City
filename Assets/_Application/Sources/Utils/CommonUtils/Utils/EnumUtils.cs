using System;
using System.Collections.Generic;
using System.Linq;

namespace Sources.Utils.CommonUtils.Utils
{
    public static class EnumUtils
    {
        public static IEnumerable<TEnum> GetAllEnums<TEnum>() where TEnum : Enum => 
            Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
    }
}
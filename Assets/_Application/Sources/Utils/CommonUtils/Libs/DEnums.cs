using System;
using System.Collections.Generic;
using System.Linq;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class DEnums
    {
        public static IEnumerable<TEnum> GetAllEnums<TEnum>() where TEnum : Enum => 
            Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
    }
}
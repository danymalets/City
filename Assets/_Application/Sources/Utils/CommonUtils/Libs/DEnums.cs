using System;
using System.Collections.Generic;
using System.Linq;

namespace Sources.Utils.Libs
{
    public static class DEnums
    {
        public static IEnumerable<TEnum> GetAllEnums<TEnum>() where TEnum : Enum => 
            Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
    }
}
using System;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class AssertUtils
    {
        public static void IsTrue(bool expression, string message = "")
        {
            if (!expression)
                throw new AssertUtilsException(message);
        }
        
        private class AssertUtilsException : Exception
        {
            public AssertUtilsException(string message) : base(message)
            {
            }
        }
    }

    
}
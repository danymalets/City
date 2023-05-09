using System;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class DAssert
    {
        public static void IsTrue(bool expression, string message = "")
        {
            if (!expression)
                throw new DAssertionException(message);
        }
        
        private class DAssertionException : Exception
        {
            public DAssertionException(string message) : base(message)
            {
            }
        }
    }

    
}
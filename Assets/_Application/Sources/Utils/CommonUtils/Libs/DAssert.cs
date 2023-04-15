using System;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class DAssert
    {
        public static void IsTrue(bool expression)
        {
            if (!expression)
                throw new DAssertionException();
        }
        
        private class DAssertionException : Exception
        {
        }
    }

    
}
using System;
using UnityEngine.Assertions;

namespace Sources.Utilities
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
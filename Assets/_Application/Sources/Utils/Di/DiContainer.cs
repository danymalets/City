using System;

namespace Sources.Utils.Di
{
    public static class DiContainer
    {
        internal static void Bind<TService>(TService implementation)
            where TService : class, IService
        {
            if (IsRegistered<TService>())
                throw new InvalidOperationException("Service has already been registered");
            
            Implementation<TService>.ServiceInstance = implementation;
        }
        
        internal static void Unbind<TService>() where TService : class, IService
        {
            if (!IsRegistered<TService>())
                throw new NullReferenceException("Service not registered");

            Implementation<TService>.ServiceInstance = null;
        }

        public static bool TryResolve<TService>(out TService service) where TService : class, IService
        {
            service = Implementation<TService>.ServiceInstance;
            return service != null;
        }

        public static TService Resolve<TService>() where TService : class, IService
        {
            TService service = Implementation<TService>.ServiceInstance;

            if (service == null)
                throw new NullReferenceException("Service not registered");

            return service;
        }

        private static bool IsRegistered<TService>() where TService : class, IService
        {
            TService service = Implementation<TService>.ServiceInstance;
            return service != null;
        }

        private static class Implementation<TService> where TService : class, IService
        {
            public static TService ServiceInstance;
        }
    }
}
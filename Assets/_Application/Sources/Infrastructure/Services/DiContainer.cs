using System;

namespace Sources.Infrastructure.Services
{
    public static class DiContainer
    {
        public static TService Register<TService>(TService implementation)
            where TService : class, IService
        {
            Initialize(implementation);
            Bind<TService>(implementation);
            return implementation;
        }
        
        public static TService Register<TImplementation, TService>()
            where TService : class, IService
            where TImplementation : class, TService, new()
        {
            return Register<TService>(new TImplementation());
        }

        public static TImplementation Register<TImplementation, TService1, TService2>()
            where TService1 : class, IService
            where TService2 : class, IService
            where TImplementation : class, TService1, TService2, new()
        {
            return Register<TImplementation, TService1, TService2>(new TImplementation());
        }

        public static TImplementation Register<TImplementation, TService1, TService2>(TImplementation implementation)
            where TService1 : class, IService
            where TService2 : class, IService
            where TImplementation : class, TService1, TService2
        {
            Initialize(implementation);
            Bind<TService1>(implementation);
            Bind<TService2>(implementation);
            return implementation;
        }

        public static TImplementation Register<TImplementation, TService1, TService2, TService3>()
            where TService1 : class, IService
            where TService2 : class, IService
            where TService3 : class, IService
            where TImplementation : class, TService1, TService2, TService3, new()
        {
            return Register<TImplementation, TService1, TService2>(new TImplementation());
        }

        public static TImplementation Register<TImplementation, TService1, TService2, TService3>(TImplementation implementation)
            where TService1 : class, IService
            where TService2 : class, IService
            where TService3 : class, IService
            where TImplementation : class, TService1, TService2, TService3
        {
            Initialize(implementation);
            Bind<TService1>(implementation);
            Bind<TService2>(implementation);
            Bind<TService3>(implementation);
            return implementation;
        }


        private static void Initialize<TService>(TService implementation)
            where TService : class, IService
        {
            if (implementation == null)
                throw new NullReferenceException("Implementation is null");
            
            if (implementation is IInitializable initializable)
                initializable.Initialize();
        }
        
        private static void Bind<TService>(TService implementation)
            where TService : class, IService
        {
            if (IsRegistered<TService>())
                throw new InvalidOperationException("Service has already been registered");
            
            Implementation<TService>.ServiceInstance = implementation;
            Implementation<TService>.ServiceRegistered?.Invoke(implementation);
        }

        public static void InvokeWhenRegistered<TService>(Action<TService> serviceRegistered)
            where TService : class, IService
        {
            if (TryResolve(out TService service))
            {
                serviceRegistered?.Invoke(service);
            }
            else
            {
                Implementation<TService>.ServiceRegistered += serviceRegistered;
            }
        }

        public static void Unregister<TService>() where TService : class, IService
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

        public static bool IsRegistered<TService>() where TService : class, IService
        {
            TService service = Implementation<TService>.ServiceInstance;
            return service != null;
        }

        private static class Implementation<TService> where TService : class, IService
        {
            public static Action<TService> ServiceRegistered;
            public static TService ServiceInstance;
        }
    }
}
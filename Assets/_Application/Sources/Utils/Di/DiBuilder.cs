using System;
using System.Collections.Generic;

namespace Sources.Utils.Di
{
    public class DiBuilder : IDiBuilder, IDisposable
    {
        public static IDiBuilder Create() =>
            new DiBuilder();

        private readonly List<ServiceWrapperBase> _serviceWrappers = new();
        
        private DiBuilder()
        {
        }
        
        public TService Register<TService>()
            where TService : class, IService, new()
        {
            return Register(new TService());
        }


        public TService Register<TService>(TService implementation)
            where TService : class, IService
        {
            Initialize(implementation);
            Bind<TService>(implementation);
            return implementation;
        }

        public TService Register<TImplementation, TService>()
            where TService : class, IService
            where TImplementation : class, TService, new()
        {
            return Register<TService>(new TImplementation());
        }

        public TImplementation Register<TImplementation, TService1, TService2>()
            where TService1 : class, IService
            where TService2 : class, IService
            where TImplementation : class, TService1, TService2, new()
        {
            return Register<TImplementation, TService1, TService2>(new TImplementation());
        }

        public TImplementation Register<TImplementation, TService1, TService2>(TImplementation implementation)
            where TService1 : class, IService
            where TService2 : class, IService
            where TImplementation : class, TService1, TService2
        {
            Initialize(implementation);
            Bind<TService1>(implementation);
            Bind<TService2>(implementation);
            return implementation;
        }

        public TImplementation Register<TImplementation, TService1, TService2, TService3>()
            where TService1 : class, IService
            where TService2 : class, IService
            where TService3 : class, IService
            where TImplementation : class, TService1, TService2, TService3, new()
        {
            return Register<TImplementation, TService1, TService2>(new TImplementation());
        }

        public TImplementation Register<TImplementation, TService1, TService2, TService3>(TImplementation implementation)
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


        private void Bind<TService>(TService implementation) where TService : class, IService
        {
            _serviceWrappers.Add(new ServiceWrapper<TService>());
            DiContainer.Bind<TService>(implementation);
        }

        public void Dispose()
        {
            foreach (ServiceWrapperBase serviceWrapper in _serviceWrappers)
            {
                serviceWrapper.Unbind();
            }
        }

        private class ServiceWrapper<TService> : ServiceWrapperBase where TService : class, IService
        {
            public override void Unbind() =>
                DiContainer.Unbind<TService>();
        }
        
        private abstract class ServiceWrapperBase
        {
            public abstract void Unbind();
        }
    }
}
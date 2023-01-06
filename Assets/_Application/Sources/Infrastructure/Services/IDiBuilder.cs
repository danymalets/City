using System;

namespace Sources.Infrastructure.Services
{
    public interface IDiBuilder
    {
        TService Register<TService>()
            where TService : class, IService, new();

        TService Register<TService>(TService implementation)
            where TService : class, IService;

        TService Register<TImplementation, TService>()
            where TService : class, IService
            where TImplementation : class, TService, new();

        TImplementation Register<TImplementation, TService1, TService2>()
            where TService1 : class, IService
            where TService2 : class, IService
            where TImplementation : class, TService1, TService2, new();

        TImplementation Register<TImplementation, TService1, TService2>(TImplementation implementation)
            where TService1 : class, IService
            where TService2 : class, IService
            where TImplementation : class, TService1, TService2;

        TImplementation Register<TImplementation, TService1, TService2, TService3>()
            where TService1 : class, IService
            where TService2 : class, IService
            where TService3 : class, IService
            where TImplementation : class, TService1, TService2, TService3, new();

        TImplementation Register<TImplementation, TService1, TService2, TService3>(TImplementation implementation)
            where TService1 : class, IService
            where TService2 : class, IService
            where TService3 : class, IService
            where TImplementation : class, TService1, TService2, TService3;

        void Dispose();
    }
}
using System;

namespace Services
{
    public class AllServices
    {
        public static AllServices instance;
        public static AllServices Container => instance ?? (instance = new AllServices());

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;
        public TService Single<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;
        private static class Implementation<TService>
        {
            public static TService ServiceInstance;
        }
    }
}

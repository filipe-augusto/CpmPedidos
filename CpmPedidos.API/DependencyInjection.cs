using Microsoft.Extensions.DependencyInjection;
using System;


namespace CpmPedidos.API
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider) 
        {
           // RepositoryDependece(serviceProvider);
            RepositoryDependence(serviceProvider);
        }

        private static  void  RepositoryDependence(IServiceCollection serviceProvider)
        {
        }
    }
}

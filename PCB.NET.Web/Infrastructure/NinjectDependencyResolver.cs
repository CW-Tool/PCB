using Ninject;
using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Repository.RepositoryPCB;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PCB.NET.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IRepositoryPCBmachine>().To<RepositoryPCBmachine>();
            kernel.Bind<IRepositoryPCBwarehouse>().To<RepositoryPCBwarehouse>();
            kernel.Bind<IRepositoryPCBemployee>().To<RepositoryPCBemployee>();
            kernel.Bind<IRepositoryPCBmap>().To<RepositoryPCBmap>();
        }
    }
}
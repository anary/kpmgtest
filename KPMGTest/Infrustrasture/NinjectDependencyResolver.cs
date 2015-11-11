using KPMG.Core.Contract;
using KPMG.Data.DAL.Entity;
using KPMG.Data.DAL.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPMG.DataProcess;

namespace KPMGTest.Infrustrasture
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            addBinding();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        private void addBinding()
        {
            kernel.Bind<IDbContext>().To<KPMGTransactionContext>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IGetData>().To<ReadInData>();
            kernel.Bind<IValidateData>().To<ValiateData>();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
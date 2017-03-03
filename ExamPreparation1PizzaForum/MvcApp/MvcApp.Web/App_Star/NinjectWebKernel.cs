namespace MvcApp.Web.App_Star
{
    using System;
    using System.Data.Entity;
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebKernel
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            bootstrapper.Initialize(CreateKernel);
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<MvcAppContext>();

            kernel.Bind(typeof(IRepository<User>)).To(typeof(DeletableEntityRepository<User>));
            kernel.Bind(typeof(IRepository<Session>)).To(typeof(DeletableEntityRepository<Session>));
            kernel.Bind(typeof(IDeletableEntityRepository<>)).To(typeof(DeletableEntityRepository<>));
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        }
    }
}

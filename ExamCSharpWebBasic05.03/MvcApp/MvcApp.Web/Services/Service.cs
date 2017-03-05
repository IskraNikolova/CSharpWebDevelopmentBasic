namespace MvcApp.Web.Services
{
    using Data.Contracts;
    using DependancyContainer;
    using Ninject;

    public abstract class Service
    {
        protected Service()
        {
            this.Context = DependencyKernel.Kernel.Get<IUnitOfWork>();
        }

        protected IUnitOfWork Context { get; }
    }
}
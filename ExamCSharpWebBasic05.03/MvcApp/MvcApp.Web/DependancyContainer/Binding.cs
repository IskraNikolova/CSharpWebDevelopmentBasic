namespace MvcApp.Web.DependancyContainer
{
    using Data;
    using Data.Contracts;
    using Ninject.Modules;

    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}

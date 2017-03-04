namespace MvcApp.Web.Services
{
    using Data;

    public abstract class Service
    {
        protected UnitOfWork unit;

        protected Service(UnitOfWork unit)
        {
            this.unit = unit;
        }
    }
}

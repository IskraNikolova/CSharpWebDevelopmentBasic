namespace PizzaMore.Services
{
    using Data;

    public abstract class Service
    {
        public readonly PizzaStoreContext context;

        protected Service(PizzaStoreContext context)
        {
            this.context = context;
        }
    }
}
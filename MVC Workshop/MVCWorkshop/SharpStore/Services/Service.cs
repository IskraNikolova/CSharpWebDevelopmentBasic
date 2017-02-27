namespace SharpStore.Services
{
    using Data;

    public abstract class Service
    {
        public readonly SharpStoreContext context;

        protected Service(SharpStoreContext context)
        {
            this.context = context;
        }
    }
}

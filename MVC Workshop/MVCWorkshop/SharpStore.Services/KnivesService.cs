namespace SharpStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Data;
    using Models;

    public class KnivesService
    {
        private readonly SharpStoreContext context;

        public KnivesService(SharpStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Knife> Knives
        {
            get { return this.context.Knives.AsEnumerable(); }
        }
    }
}

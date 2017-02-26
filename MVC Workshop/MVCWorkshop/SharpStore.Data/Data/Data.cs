namespace SharpStore.Data.Data
{
    public class Data
    {
        private static SharpStoreContext context;

        public static SharpStoreContext Context => context ?? (context = new SharpStoreContext());
    }
}

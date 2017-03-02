namespace Shouter.Data
{
    public class Data
    {
        private static ShouterContext context;

        public ShouterContext Context
        {
            get { return context ?? (context = new ShouterContext()); }
        }
    }
}
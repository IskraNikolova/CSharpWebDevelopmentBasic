namespace MvcApp.Data
{
    public class Data
    {
        private static MvcAppContext context;

        public static MvcAppContext Context
        {
            get { return context ?? (context = new MvcAppContext()); }
        }
    }
}
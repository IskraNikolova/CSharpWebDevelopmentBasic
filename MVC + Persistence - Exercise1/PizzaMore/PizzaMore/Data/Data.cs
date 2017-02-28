namespace PizzaMore.Data
{
    public class Data
    {
        private static PizzaStoreContext context;

        public static PizzaStoreContext Context
        {
            get { return context ?? (context = new PizzaStoreContext());}
        }
    }
}
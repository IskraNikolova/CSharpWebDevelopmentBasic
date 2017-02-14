namespace SharpStore.Data
{
    public class Data
    {
        private static SharpStoryContext context;

        public static SharpStoryContext Context
        {
            get { return context ?? new SharpStoryContext(); }
        }
    }
}

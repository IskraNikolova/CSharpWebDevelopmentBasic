namespace SharpStoreServices
{
    using System.Collections.Generic;
    using System.Linq;
    using SharpStore.Data;
    using SharpStore.Data.Models;
    using SimpleHttpServer.Utilities;

    public class KnivesService
    {
        private SharpStoryContext context = Data.Context;
        public IList<Knife> GetAllKnivesFromUrl(string url)
        {
            int index = url.IndexOf('?');
            if (index == -1)
            {
                return this.context.Knives.ToList();
            }

            var variables = QueryStringParser.Parser(url.Substring(index + 1));
            var knifeName = variables["knife-name"];
            return this.context.Knives
                .Where(knife => knife.Name.Contains(knifeName))
                .ToList();
        }
    }
}

namespace MvcApp.Web.ViewModels
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class AllViewModel
    {
        public SignedViewModel SignedModel { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (CategoryViewModel categoryViewModel in this.Categories)
            {
                builder.Append(categoryViewModel);
            }

            return builder.ToString();
        }
    }
}

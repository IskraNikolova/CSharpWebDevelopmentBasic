namespace MvcApp.Web.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public override string ToString()
        {
            string representation = "<tr>" +
                                        $"<td><a href=\"#\">{this.CategoryName}</a></td>" +
                                        $"<td><a href=\"/categories/edit?id={this.Id}\" class=\"btn btn-primary\">Edit</a></td>" +
                                        $"<td><a href=\"/categories/delete?id={this.Id}\" class=\"btn btn-danger\">Delete</a></td>"+
                                    "</tr>";
            return representation;
        }
    }
}

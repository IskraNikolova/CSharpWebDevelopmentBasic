namespace MvcApp.Web.ViewModels
{
    public class RegisterValidationModel
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return $@"<div class=""alert alert-danger"">
                      <strong>Danger!</strong> {this.Message}
                    </div>";
        }
    }
}

namespace SimpleMVC.App.Mvc.Attributes.Methods
{
    public class HttpPostAttributes : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "POST")
            {
                return true;
            }

            return false;
        }
    }
}

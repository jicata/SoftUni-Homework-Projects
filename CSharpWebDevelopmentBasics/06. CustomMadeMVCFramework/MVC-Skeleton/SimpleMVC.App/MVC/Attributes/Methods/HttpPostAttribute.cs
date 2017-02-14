namespace SimpleMVC.App.MVC.Attributes.Methods
{
    class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool isValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "POST")
            {
                return true;
            }
            return false;
        }
    }
}

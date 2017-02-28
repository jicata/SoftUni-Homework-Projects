namespace IssueTracker.Models.ViewModels
{
    public class RegistrationVerificationErrorViewModel
    {
        public RegistrationVerificationErrorViewModel(string message)
        {
            this.Message = message;
        }
        public string Message { get; set; }

        public override string ToString()
        {
            string template = $@"<div class=""alert alert-danger alert-dismissable"">
                                  <a href=""#"" class=""close"" data-dismiss=""alert"" aria-label=""close"">&times;</a>
                                  <strong>Error!</strong> {this.Message}
                                </div>";
            return template;
        }
    }
}

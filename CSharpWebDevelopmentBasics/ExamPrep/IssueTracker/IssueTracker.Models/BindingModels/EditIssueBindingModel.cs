namespace IssueTracker.Models.BindingModels
{
    public class EditIssueBindingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }
    }
}

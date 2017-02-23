namespace MVCFramework.MVC.Interfaces
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}

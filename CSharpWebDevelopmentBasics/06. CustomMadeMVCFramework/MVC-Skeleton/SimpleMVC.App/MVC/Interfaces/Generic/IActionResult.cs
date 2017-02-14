namespace SimpleMVC.App.MVC.Interfaces.Generic
{
    public interface IActionResult<T> : IInvocable
    {
        IRenderable<T> Action { get; set; }
    }
}

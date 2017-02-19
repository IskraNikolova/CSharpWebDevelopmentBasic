namespace SimpleMVC.App.Mvc.Interfaces
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}
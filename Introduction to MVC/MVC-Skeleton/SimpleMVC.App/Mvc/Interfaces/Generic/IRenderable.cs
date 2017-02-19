namespace SimpleMVC.App.Mvc.Interfaces.Generic
{
    public interface IRenderable<T> : IRenderable
    {
        T Model { get; set; }
    }
}

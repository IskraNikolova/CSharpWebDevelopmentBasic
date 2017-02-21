namespace SimpleMVC.App.Mvc.ViewEngine
{
    using System;
    using Interfaces;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
            :this(viewFullQualifedName, string.Empty)
        {            
        }

        public ActionResult(string viewFullQualifedName, string location)
        {
            this.Action = (IRenderable) Activator
                .CreateInstance(Type.GetType(viewFullQualifedName));

            this.Location = location;
        }

        public IRenderable Action { get; set; }

        public string Location { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
namespace SimpleHttpServer.Models
{
    using System.Collections.Generic;

    public class HttpSession
    {
        private IDictionary<string, string> parameters;

        public HttpSession(string id)
        {
           this.parameters = new Dictionary<string, string>();
           this.Id = id;
        }

        public string Id { get; set; }

        public string this[string key]
        {
            get { return this.parameters[key]; }
        }

        public void Clear()
        {
            this.parameters = new Dictionary<string, string>();
        }

        public void Add(string key, string value)
        {
            this.parameters.Add(key, value);
        }
    }
}
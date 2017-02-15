namespace SharpStoreServices
{
    using System.Collections.Generic;
    using SharpStore.Data;
    using SharpStore.Data.Models;

    public class MessagesService
    {
        private SharpStoryContext context;

        public MessagesService()
        {
            this.context = Data.Context;
        }

        public void AddMessageFromPostVariables(IDictionary<string, string> vars)
        {
            Message message = new Message()
            {
                Sender = vars["email"],
                Subject = vars["subject"],
                MessageText = vars["message-text"]
            };

            this.context.Messages.Add(message);
            this.context.SaveChanges();
        }
    }
}

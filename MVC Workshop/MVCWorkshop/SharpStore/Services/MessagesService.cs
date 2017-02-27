namespace SharpStore.Services
{
    using BindingModels;
    using Data;
    using Models;

    public class MessagesService
    {
        private SharpStoreContext context;

        public MessagesService(SharpStoreContext context)
        {
            this.context = context;
        }

        public void AddMessageFromBind(MessageBinding messageBindingModel)
        {
            Message message = new Message()
            {
                Email = messageBindingModel.Email,               
                Subject = messageBindingModel.Subject,
                Messagetext = messageBindingModel.Messagetext,
            };

            this.context.Messages.Add(message);
            this.context.SaveChanges();
        }
    }
}

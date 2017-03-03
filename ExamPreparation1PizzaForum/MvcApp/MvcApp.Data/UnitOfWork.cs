namespace MvcApp.Data
{
    using Common.Repository;
    using Models;

    public class UnitOfWork
    {
        private readonly MvcAppContext context = MvcAppContext.Create();

        private IDeletableEntityRepository<User> users;
        private IDeletableEntityRepository<Category> categories;
        private IDeletableEntityRepository<Topic> topics;
        private IDeletableEntityRepository<Session> sessions;

        public void Save()
        {
            this.context.SaveChanges();
        }

        public IDeletableEntityRepository<User> Users => this.users ?? (this.users = new DeletableEntityRepository<User>(this.context));

        public IDeletableEntityRepository<Session> Sessions => this.sessions ?? (this.sessions = new DeletableEntityRepository<Session>(this.context));

        public IDeletableEntityRepository<Topic> Topics => this.topics ?? (this.topics = new DeletableEntityRepository<Topic>(this.context));
    
        public IDeletableEntityRepository<Category> Categories => this.categories ?? (this.categories = new DeletableEntityRepository<Category>(this.context));
    }
}

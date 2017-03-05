namespace MvcApp.Data
{
    using Common.Repository;
    using Contracts;
    using Models;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MvcAppContext context = MvcAppContext.Create();

        private IDeletableEntityRepository<User> users;
        private IDeletableEntityRepository<Login> sessions;
        private IDeletableEntityRepository<Issue> issues;

        public IDeletableEntityRepository<User> Users => this.users ?? (this.users = new DeletableEntityRepository<User>(this.context));

        public IDeletableEntityRepository<Login> Sessions => this.sessions ?? (this.sessions = new DeletableEntityRepository<Login>(this.context));

        public IDeletableEntityRepository<Issue> Issues => this.issues ?? (this.issues = new DeletableEntityRepository<Issue>(this.context));

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

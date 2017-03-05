namespace MvcApp.Data.Contracts
{
    using Common.Repository;
    using Models;

    public interface IUnitOfWork
    {
        IDeletableEntityRepository<Issue> Issues { get; }

        IDeletableEntityRepository<Login> Sessions { get; }

        IDeletableEntityRepository<User> Users { get; }

        void Save();
    }
}

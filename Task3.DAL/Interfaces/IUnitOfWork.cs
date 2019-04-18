namespace Task3.DAL.Interfaces
{
    using Task3.DAL.Entities;

    public interface IUnitOfWork
    {
        IRepository<BusinessEntity1> BusinessEntities1Repo { get; }
    }
}
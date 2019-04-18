namespace Task3.DAL
{
    using Task3.DAL.Entities;
    using Task3.DAL.Interfaces;
    using Task3.DAL.Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<BusinessEntity1> _businessEntities1Repo;

        public IRepository<BusinessEntity1> BusinessEntities1Repo
        {
            get
            {
                if (_businessEntities1Repo == null)
                {
                    _businessEntities1Repo = new BusinessProcessRepository();
                }

                return _businessEntities1Repo;
            }
        }
    }
}
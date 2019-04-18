using static System.Console;

namespace Task3.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Task3.DAL.DB;
    using Task3.DAL.Entities;
    using Task3.DAL.Interfaces;

    public class BusinessProcessRepository : IBusinessProcessRepository
    {
        private readonly List<BusinessEntity1> db = BusinessEntityDb.EntitiesDummyList;

        public void Create(BusinessEntity1 item)
        {
            WriteLine("Item created");
            db.Add(item);
        }

        public void Delete(int id)
        {
            WriteLine("Item deleted");
            var item = db.Single(x => x.Id == id);
            db.Remove(item);
        }

        public void Dispose()
        {
        }

        public BusinessEntity1 Get(int id)
        {
            WriteLine($"Return Item ID = {id}");
            return db.Single(x => x.Id == id);
        }

        public IEnumerable<BusinessEntity1> GetAll()
        {
            foreach (var businessEntity1 in db)
            {
                WriteLine(businessEntity1);
            }

            return db;
        }

        public void Save()
        {
            // todo save context
        }

        public void Update(BusinessEntity1 item)
        {
            WriteLine("Item updated");
            var value = db.Single(x => x.Id == item.Id);

            value.Name = item.Name;
            value.Description = item.Description;
        }
    }
}
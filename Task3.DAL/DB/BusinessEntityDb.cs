namespace Task3.DAL.DB
{
    using System.Collections.Generic;
    using System.Linq;

    using Task3.DAL.Entities;

    public static class BusinessEntityDb
    {
        public static List<BusinessEntity1> EntitiesDummyList = new List<BusinessEntity1>();

        static BusinessEntityDb()
        {
            // init sample db
            if (!EntitiesDummyList.Any())
            {
                EntitiesDummyList.Add(new BusinessEntity1 { Id = 1, Name = "Entity1" });
                EntitiesDummyList.Add(new BusinessEntity1 { Id = 2, Name = "Entity2" });
                EntitiesDummyList.Add(new BusinessEntity1 { Id = 3, Name = "Entity3" });
                EntitiesDummyList.Add(new BusinessEntity1 { Id = 4, Name = "Entity4" });
                EntitiesDummyList.Add(new BusinessEntity1 { Id = 5, Name = "Entity5" });
            }
        }
    }
}
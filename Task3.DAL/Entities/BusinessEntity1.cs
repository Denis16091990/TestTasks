namespace Task3.DAL.Entities
{
    using Task3.DAL.Interfaces;

    public class BusinessEntity1 : IBusinessEntity1
    {
        public string Description { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"[Id = {Id}, Name={Name}, Description= {Description}]";
        }
    }
}
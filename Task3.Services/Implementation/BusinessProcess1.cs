using static System.Console;

namespace Task3.Services.Implementation
{
    using Task3.DAL.Entities;
    using Task3.DAL.Interfaces;
    using Task3.Services.Interfaces;

    public class BusinessProcess1 : IBusinessProcess1
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusinessProcess1(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DoSomeProcess()
        {
            WriteLine("BusinessProcess1 starting");
            WriteLine("Print existing Item");
            _unitOfWork.BusinessEntities1Repo.GetAll();
            var newItem = new BusinessEntity1();
            while (true)
            {
                WriteLine("Please input new Item Id (int)");
                var input = ReadLine();
                if (int.TryParse(input, out var result))
                {
                    newItem.Id = result;
                    break;
                }

                WriteLine("Incorrect input");
            }

            WriteLine("Please input new Item Name ");
            newItem.Name = ReadLine();

            _unitOfWork.BusinessEntities1Repo.Create(newItem);
            _unitOfWork.BusinessEntities1Repo.GetAll();
            WriteLine("BusinessProcess1 finished");
        }
    }
}
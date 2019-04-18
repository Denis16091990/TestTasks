using static System.Console;

namespace Task3
{
    using Autofac;

    using Task3.DAL;
    using Task3.DAL.Interfaces;
    using Task3.Services.Implementation;
    using Task3.Services.Interfaces;

    internal class Program
    {
        /// <summary>
        ///     define IoC contaiber
        /// </summary>
        /// <returns></returns>
        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // init service
            builder.RegisterType<BusinessProcess1>().As<IBusinessProcess1>();

            // init repositories
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            return builder.Build();
        }

        private static void Main(string[] args)
        {
            var iocContainer = BuildContainer();
            var service = iocContainer.Resolve<IBusinessProcess1>();

            service.DoSomeProcess();
            WriteLine("Press any key to continue");
            ReadKey();
        }
    }
}
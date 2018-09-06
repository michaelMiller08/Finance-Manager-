using Autofac;
using FinanceManager.ViewModels;

namespace FinanceManager
{
    public static class App
    {
        public static IContainer Container { get; set; }

        static App()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new BillRepository()).As<IBillRepository>();
            Container = builder.Build();
        }
    }
}
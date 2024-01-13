using Autofac;
using Exam1.Application.Feature;
using Exam1.Domain.Feature;

namespace Exam1.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManagementService>().As<IProductManagementService>()
                .InstancePerLifetimeScope();

        }
    }
}

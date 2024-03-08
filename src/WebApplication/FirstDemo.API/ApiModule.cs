using Autofac;
using FirstDemo.API.RequestHandlers;
using FirstDemo.Infrastructure.Membership;
namespace FirstDemo.API
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewCourseRequestHandler>().AsSelf();

            base.Load(builder);
        }
    }
}

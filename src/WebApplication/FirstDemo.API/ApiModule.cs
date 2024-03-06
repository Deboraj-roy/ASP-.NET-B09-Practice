using Autofac;
using FirstDemo.API.RequestHandlers;

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

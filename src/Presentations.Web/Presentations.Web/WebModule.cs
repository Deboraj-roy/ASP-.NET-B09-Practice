
using Autofac;

namespace Presentations.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<UnicodeSmsSender>().As<ISmsSender>();
            //builder.RegisterType<CourseCreateModel>().AsSelf();
            //builder.RegisterType<CourseListModel>().AsSelf();
        }
    }
}

using Autofac;
using Presentations.Application.Features.Training;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseManagementService>().As<CourseManagementService>()
                .InstancePerLifetimeScope();
        }
    }
}

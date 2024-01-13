using Autofac;
using Exam1.Application.Feature;
using Exam1.Domain.Entity;
using Exam1.Domain.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

﻿using Autofac;
using Exam1.Application;
using Exam1.Domain.Repositories;
using Exam1.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _conncetionString;
        private readonly string _migrationAssembly;

        public InfrastructureModule(string conncetionString, string migrationAssembly)
        {
            _conncetionString = conncetionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("conncetionString", _conncetionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("conncetionString", _conncetionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<IApplicationUnitofWork>().As<IApplicationUnitofWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();
        }
    }
}

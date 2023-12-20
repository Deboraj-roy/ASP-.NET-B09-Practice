﻿using FirstDemo.Application;
using FirstDemo.Domain.Repositories;
using FirstDemo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ICourseRepository CourseRepository { get; private set; }

        public ApplicationUnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
        {
            CourseRepository = new CourseRepository(dbContext);
        }
    }
}

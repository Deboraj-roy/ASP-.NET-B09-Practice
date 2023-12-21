using Presentations.Domain;
using Presentations.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
    }
}

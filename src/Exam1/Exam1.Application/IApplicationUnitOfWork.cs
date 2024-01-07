using Exam1.Domain;
using Exam1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}

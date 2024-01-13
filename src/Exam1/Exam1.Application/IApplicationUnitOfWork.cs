using Exam1.Domain;
using Exam1.Domain.Repository;

namespace Exam1.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    { 
        IProductRepository ProductRepository { get; }
    }
}

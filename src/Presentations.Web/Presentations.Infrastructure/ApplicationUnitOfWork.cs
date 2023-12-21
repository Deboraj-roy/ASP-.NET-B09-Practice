using Presentations.Application;
using Presentations.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using FirstDemo.Infrastructure;

namespace Presentations.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
	{
		public ICourseRepository CourseRepository { get; private set; }

		public ApplicationUnitOfWork(ICourseRepository courseRepository, 
			IApplicationDbContext dbContext) : base((DbContext)dbContext)
		{
			CourseRepository = courseRepository;
		}
	}
}

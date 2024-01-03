using FirstDemo.Domain.Entities;
using FirstDemo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        public CourseRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

        public async Task<(IList<Course> records, int total, int totalDisplay)> 
            GetTableDataAsync(string searchTitle, uint searchFeeFrom, uint searchFeeTo, string orderBy, int pageIndex, int pageSize)
        {
            Expression<Func<Course, bool>> expression = null;
            if(!string.IsNullOrWhiteSpace(searchTitle))
            {
                expression = x => x.Title.Contains(searchTitle) &&
                (x.Fees >= searchFeeFrom && x.Fees <= searchFeeTo);
            }
            return await GetDynamicAsync(expression,
                orderBy, null, pageIndex, pageSize, true);
        }

        public async Task<bool> IsTitleDuplicateAsync(string title, Guid? id = null)
        {
            if(id.HasValue)
            {
                return (await GetCountAsync(x => x.Id != id.Value && x.Title == title)) > 0;
            }
            else
            {
                return (await GetCountAsync(x => x.Title == title)) > 0;
            }
        }
    }
}

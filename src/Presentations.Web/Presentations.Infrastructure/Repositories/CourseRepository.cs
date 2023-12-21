using Microsoft.EntityFrameworkCore;
using Presentations.Domain.Entities;
using Presentations.Domain.Repositories;
using Presentations.Infrastructure.Repositories;

namespace FirstDemo.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
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

        public async Task<(IList<Course> records, int total, int totalDisplay)>
            GetTableDataAsync(string searchText, string orderBy, 
                int pageIndex, int pageSize)
        {
            return await GetDynamicAsync(x => x.Title.Contains(searchText), 
                orderBy, null, pageIndex, pageSize, true);
        }
    }
}

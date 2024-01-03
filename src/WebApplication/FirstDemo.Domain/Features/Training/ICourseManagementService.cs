using FirstDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Domain.Features.Training
{
    public interface ICourseManagementService
    {
        Task CreateCourseAsync(string title, string description, uint fees);
        Task DeleteCourseAsync(Guid id);
        Task<Course> GetCourseAsync(Guid id);
        Task<(IList<Course> records, int total, int totalDisplay)>
            GetPagedCoursesAsync(int pageIndex, int pageSize, string searchTitle, uint searchFeeFrom,
            uint searchFeeTo, string sortBy);
        Task UpdateCourseAsync(Guid id, string title, string description, uint fees);
    }
}

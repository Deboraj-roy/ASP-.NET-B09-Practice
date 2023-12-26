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
        Task CreateCourseAsync(string title, uint fees, string description);

        Task<(IList<Course> records, int total, int totalDisplay)>
            GetPagedCoursesAsync(int pageIndex, int pageSize, string searchText,
            string sortBy);
    }
}

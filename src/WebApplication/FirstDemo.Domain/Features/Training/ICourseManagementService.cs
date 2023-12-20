using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Domain.Features.Training
{
    public interface ICourseManagementService
    {
        void CreateCourse(string title, uint fees, string description);
    }
}

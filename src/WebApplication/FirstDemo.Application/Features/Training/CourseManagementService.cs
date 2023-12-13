using FirstDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Application.Features.Training
{
    public class CourseManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        
        public CourseManagementService(IApplicationUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateCourse(string title, uint fee, string description)
        {
            Course course = new Course
            {
                Title = title,
                Fees = fee,
                Description = description
            };
            _unitOfWork.CourseRepository.Add(course);
            _unitOfWork.Save();

        }
    }
}

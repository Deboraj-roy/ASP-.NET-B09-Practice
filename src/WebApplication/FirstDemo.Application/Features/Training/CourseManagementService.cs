using FirstDemo.Domain.Entities;
using FirstDemo.Domain.Exceptions;
using FirstDemo.Domain.Features.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Application.Features.Training
{
    public class CourseManagementService : ICourseManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public CourseManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCourseAsync(string title, string description, uint fees)
        {
            bool isDuplicateTitle = await _unitOfWork.CourseRepository.IsTitleDuplicateAsync(title);

            if (isDuplicateTitle)
                throw new DuplicateTitleException();

            Course course = new Course
            {
                Title = title,
                Fees = fees,
                Description = description
            };

            _unitOfWork.CourseRepository.Add(course);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCourseAsync(Guid id)
        {
            await _unitOfWork.CourseRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Course> GetCourseAsync(Guid id)
        {
            return await _unitOfWork.CourseRepository.GetByIdAsync(id);
        }

        public async Task<(IList<Course> records, int total, int totalDisplay)> GetPagedCoursesAsync(int pageIndex, int pageSize, string searchText, string sortBy)
        {
            return await _unitOfWork.CourseRepository.GetTableDataAsync(searchText, sortBy, pageIndex, pageSize);

        }

        public async Task UpdateCourseAsync(Guid id, string title, string description, uint fees)
        {
            bool isDuplicateTitle = await _unitOfWork.CourseRepository
                .IsTitleDuplicateAsync(title,id);
            if (isDuplicateTitle)
                throw new DuplicateTitleException();
            var course = await GetCourseAsync(id);
            if(course is not null)
            {
                course.Title = title;
                course.Description = description;
                course.Fees = fees;
            }

            await _unitOfWork.SaveAsync();
        }
    }

}

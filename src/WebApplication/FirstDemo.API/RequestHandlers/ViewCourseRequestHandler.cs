using Autofac;
using AutoMapper;
using FirstDemo.Application.Features.Training.Services;
using FirstDemo.Domain.Entities;
using FirstDemo.Infrastructure;

namespace FirstDemo.API.RequestHandlers
{
    public class ViewCourseRequestHandler
    {
        private ICourseManagementService? _courseService;
        private IMapper _mapper;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Fees { get; set; }
        public string Description { get; set; }

        public CourseSearch SearchItem { get; set; }

        public ViewCourseRequestHandler()
        {

        }

        public ViewCourseRequestHandler(ICourseManagementService coursService, IMapper mapper)
        {
            _courseService = coursService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _courseService = scope.Resolve<ICourseManagementService>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal async Task<IList<Course>>? GetCoursesAsync()
        {
            return await _courseService?.GetCoursesAsync();
        }

        internal void DeleteCourse(Guid id)
        {
            _courseService?.DeleteCourseAsync(id);
        }

        internal async Task CreateCourse()
        {
            await _courseService?.CreateCourseAsync(Name, Description, Fees);
        }

        internal async Task UpdateCourse()
        {
            await _courseService?.UpdateCourseAsync(Id, Name, Description, Fees);
        }

        //internal Course GetCourse(string name)
        //{
        //    return _courseService.GetCourse(name);
        //}

        internal async Task<Course>? GetCourseAsync(Guid id)
        {
            return await _courseService?.GetCourseAsync(id);
        }

        internal async Task<object?> GetPagedCourses(DataTablesAjaxRequestUtility model)
        {

            var data = await _courseService?.GetPagedCoursesAsync(
                model.PageIndex,
                model.PageSize,
                SearchItem.Title,
                SearchItem.CourseFeesFrom,
                SearchItem.CourseFeesTo,
                model.GetSortText(new string[] { "Title", "Description", "Fees" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Title,
                                record.Description,
                                record.Fees.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}

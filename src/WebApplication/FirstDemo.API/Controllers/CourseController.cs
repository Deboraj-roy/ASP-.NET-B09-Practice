using Autofac; 
using FirstDemo.API.RequestHandlers;
using FirstDemo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using FirstDemo.Infrastructure.Membership;
using FirstDemo.Infrastructure;

namespace FirstDemo.API.Controllers
{
    [ApiController]
    [Route("v3/[controller]")]
    [EnableCors("AllowSites")]
    public class CourseController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }


        [HttpPost, Authorize(Policy = "CourseViewRequirementPolicy")]
        public async Task<object> Post([FromBody] ViewCourseRequestHandler handler)
        {
            handler.ResolveDependency(_scope);
            _logger.LogInformation($"Origin:" + Request.Headers.Origin.Count);

            var data = await handler.GetPagedCourses();
            return data;
        }  
         
         /*
        [HttpGet, Authorize(Policy = "CourseViewRequirementPolicy")]
        public async Task<IEnumerable<Course>> Get()
        {
            try
            {
                var model = _scope.Resolve<ViewCourseRequestHandler>();
                return await model?.GetCoursesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't get courses");
                return null;
            }
        }
*/

        [HttpGet("{id}")]
        //[Authorize(Policy = "CourseViewRequirementPolicy")]
        public async Task<Course> Get(Guid id)
        {
            var model = _scope.Resolve<ViewCourseRequestHandler>();
            return await model?.GetCourseAsync(id);
        }

        //[HttpGet("{name}")]
        //public Course Get(string name)
        //{
        //    var model = _scope.Resolve<CourseModel>();
        //    return model.GetCourse(name);
        //}

        //[HttpPost()]
        //public IActionResult Post([FromBody] ViewCourseRequestHandler model)
        //{
        //    try
        //    {
        //        model.ResolveDependency(_scope);
        //        model.CreateCourse();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Couldn't delete course");
        //        return BadRequest();
        //    }
        //}

        //[HttpPut]
        //public IActionResult Put(ViewCourseRequestHandler model)
        //{
        //    try
        //    {
        //        model.ResolveDependency(_scope);
        //        model.UpdateCourse();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Couldn't delete course");
        //        return BadRequest();
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(Guid id)
        //{
        //    try
        //    {
        //        var model = _scope.Resolve<CourseModel>();
        //        model.DeleteCourse(id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Couldn't delete course");
        //        return BadRequest();
        //    }
        //}
    }
}
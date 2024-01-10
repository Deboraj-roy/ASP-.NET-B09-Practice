using AutoMapper;
using FirstDemo.Domain.Entities;
using FirstDemo.Web.Areas.Admin.Models;

namespace FirstDemo.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CourseUpdateModel, Course>()
                .ReverseMap();
        }
    }
}

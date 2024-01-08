using AutoMapper;
using Exam1.Domain.Entities;
using Exam1.Web.Areas.Admin.Models;

namespace Exam1.Web
{
    public class WebProfile : Profile
    {
        public WebProfile() 
        {
            CreateMap<ProductUpdateModel, Product>().ReverseMap();
        }
    }
}

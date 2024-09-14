using Autofac;
using FirstDemo.API.RequestHandlers;
using FirstDemo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using FirstDemo.Infrastructure.Membership;
using FirstDemo.Infrastructure;
using FirstDemo.API.Models;
using FirstDemo.API.Features.Students.Commands;
using AutoMapper;
using FirstDemo.API.Features.Students.Queries;
using MediatR;

namespace FirstDemo.API.Controllers
{
    [ApiController]
    [Route("v3/[controller]")]
    [EnableCors("AllowSites")]
    public class StudentController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public StudentController(ILogger<CourseController> logger, ILifetimeScope scope, 
            IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _scope = scope;
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpPost, Authorize(Policy = "CourseViewRequirementPolicy")]
        public ActionResult Post(CreateStudentModel model)
        { 
            //var command = _mapper.Map<CreateStudentModel, CreateStudentCommand>(model);
            //var handler = new CreateStudentCommandHandler();
            //handler.Handle(command);
            var command = _mapper.Map<CreateStudentModel, CreateStudentCommand>(model);
            _mediator.Send(command);
            return Ok();
        }


        [HttpGet("{id}")]
        public Student Get(Guid id)
        {
            var query = new GetStudentByIdQuery(id);
            var handler = new GetStudentByIdQueryHandler();
            return handler.Handle(query);
        }
    }

}
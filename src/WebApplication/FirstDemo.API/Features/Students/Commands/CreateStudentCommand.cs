using MediatR;

namespace FirstDemo.API.Features.Students.Commands
{
    public class CreateStudentCommand : IRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public double CGPA { get; set; }

    }
}

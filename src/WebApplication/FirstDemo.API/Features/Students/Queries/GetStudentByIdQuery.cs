using FirstDemo.Application.Features;

namespace FirstDemo.API.Features.Students.Queries
{
    public class GetStudentByIdQuery : IQuery
    {
        private Guid id;

        public GetStudentByIdQuery(Guid id)
        {
            this.id = id;
        }
    }
}

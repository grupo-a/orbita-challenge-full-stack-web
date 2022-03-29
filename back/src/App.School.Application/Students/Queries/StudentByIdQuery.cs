using App.School.Application.Students.Responses;
using MediatR;

namespace App.School.Application.Students.Queries
{
    public class StudentByIdQuery : IRequest<StudentByIdResponse>
    {
        public int Id { get; set; }
    }
}

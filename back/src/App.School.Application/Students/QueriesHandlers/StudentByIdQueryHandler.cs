using App.School.Application.Students.Queries;
using App.School.Application.Students.Responses;
using MediatR;

namespace App.School.Application.Students.QueriesHandlers
{
    public class StudentByIdQueryHandler : IRequestHandler<StudentByIdQuery, StudentByIdResponse>
    {
        public async Task<StudentByIdResponse> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            //TODO: seguir com repository
            return await Task.FromResult(new StudentByIdResponse { Description = $"Description" });
        }
    }
}

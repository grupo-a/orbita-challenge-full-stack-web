using App.School.Application.Students.Commands;
using App.School.Application.Students.Responses;

namespace App.School.Application.Students.CommandHandlers
{
    public class CreateStudentHandler
    {
        public CreateStudentResponse Handle(CreateStudentCommand command)
        {
            //TODO
            return new CreateStudentResponse() 
            { 
                Description = "teste",
                Name = command.Name,
            };
        }
    }
}

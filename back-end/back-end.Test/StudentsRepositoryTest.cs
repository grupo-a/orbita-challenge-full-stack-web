namespace back_end.Test;
using Xunit;
using FluentAssertions;
using students_db.Models;
using students_db.Repository;
using students_data.Test;

public class StudentsRepositoryTest
{
    [Theory]
    [InlineData("Student 1", "student@email.com", 1111111111, 012345678911)]
    public void CreateStudent(string name, string email, int ra, int cpf)
    {
        var _context = new StudentsContextTest();
        var _repository = new StudentsRepository(_context);

        var student = new Student
        {
            RA = ra,
            Name = name,
            Email = email,
            CPF = cpf
        };

        var expected = _repository.Add(student);
        expected.Should().Be(student);

        _repository.GetAll().Count().Should().Be(1);
        _repository.GetById(student.RA).Should().Be(student);
    }
}
using Microsoft.EntityFrameworkCore;
using students_db.Models;

namespace students_db.Repository;

public class StudentsRepository
{
    protected readonly StudentsContext _context;
    public StudentsRepository(StudentsContext context)
    {
        _context = context;
    }

    public List<Student?> GetAll()
    {
        return _context.Students.ToList();
    }

    public Student GetByPK(int ra)
    {
        return _context.Students.Where(e => e.RA == ra).First();
    }

    public Student Create(Student student)
    {
        _context.Add(student);
        _context.SaveChanges();
        return student;
    }

    public virtual void Update(Student student)
    {
        _context.Update(student);
        _context.SaveChanges();
    }

    public virtual void Delete(int ra)
    {
        var student = _context.Students.Where(e => e.RA == ra).First();
        _context.Remove(student);
        _context.SaveChanges();
    }
}
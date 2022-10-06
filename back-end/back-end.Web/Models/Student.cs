using System.ComponentModel.DataAnnotations;

namespace students_db.Models;
public class Student
{
    [Key]
    [Required(ErrorMessage="Required field")]
    public int RA { get; set; }
    [Required(ErrorMessage="Required field")]
    [MinLength(3, ErrorMessage="Name must be at least 3 characters long")]
    public string Name { get; set; }
    [Required(ErrorMessage="Required field")]
    [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Email must be in a valid format")]
    public string Email { get; set; }
    [Required(ErrorMessage="Required field")]
    [Range(11, int.MinValue, ErrorMessage = "CPF must be in a valid format")]
    public int CPF { get; set; }

}
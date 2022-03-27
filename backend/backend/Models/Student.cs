using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Student
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The e-mail is required")]
        [EmailAddress(ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; } 
        [Required(ErrorMessage = "The RA is required")]
        public string Ra { get; set; }
        [Required(ErrorMessage = "The CPF is required")]
        [RegularExpression("^([0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2})|([0-9]{11})|([0-9]{9}-[0-9]{2})$", ErrorMessage = "CPF must have 11 digits")]
        public string Cpf { get; set; }

    }
}

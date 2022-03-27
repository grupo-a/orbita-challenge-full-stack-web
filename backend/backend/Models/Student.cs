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
        [MinLength(11, ErrorMessage = "CPF must have 11 digits"), MaxLength(11, ErrorMessage = "CPF must have 11 digits")]
        public string Cpf { get; set; }

    }
}

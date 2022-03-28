using System.ComponentModel.DataAnnotations;

namespace backend.Data.Dtos
{
    public class UpdateStudentDTO
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The e-mail is required")]
        [EmailAddress(ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; }
    }
}

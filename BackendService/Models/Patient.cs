using System.ComponentModel.DataAnnotations;

namespace BackendService.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Not a valid phone number")]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; } = string.Empty;
    }
}

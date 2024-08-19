namespace BackendService.Models.DTO
{
    public class UpdatePatientDTO
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}

namespace BackendService.Models.DTO
{
    public class PatientDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}

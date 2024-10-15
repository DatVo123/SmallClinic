namespace SmallClinic.API.DTOs
{
    public class DoctorDTO
    {
        public string Code { get; set; }
        public string Name { get; set; } 
        public Guid GenderId { get; set; } 
        public Guid SpecialityId { get; set; }
    }
}

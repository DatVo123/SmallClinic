namespace SmallClinic.API.DTOs
{
    public class DoctorDTO
    {
        public string Code { get; private set; }
        public string Name { get; private set; } 
        public Guid GenderId { get; private set; } 
        public Guid SpecialityId { get; private set; }
    }
}

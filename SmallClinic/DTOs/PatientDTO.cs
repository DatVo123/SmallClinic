
namespace SmallClinic.API.DTOs
{
    public class PatientDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }  
        public Guid GenderId { get; set; }  
    }
}

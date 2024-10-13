namespace SmallClinic.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}

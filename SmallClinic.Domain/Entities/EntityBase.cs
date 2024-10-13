using System.ComponentModel.DataAnnotations;

namespace SmallClinic.Domain.Entities
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EntityBase() {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreateDate = DateTime.Now;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
    }
}

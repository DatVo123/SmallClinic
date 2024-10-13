namespace SmallClinic.Domain.Interfaces
{
    public interface IValidator
    {
        public bool ValidateQuantity(int quantity);
        public bool ValidatePrice(decimal price);

    }
}

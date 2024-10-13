using SmallClinic.Domain.Interfaces;

namespace SmallClinic.Application.Services
{
    public class ValidatorService : IValidator
    {
        public bool ValidateQuantity(int quantity)
        {
            return quantity >= 0; 
        }

        public bool ValidatePrice(decimal price)
        {
            return price >= 0;
        }

    }
}

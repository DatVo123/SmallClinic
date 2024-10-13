using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmallClinic.Application.Services
{
    public class UserService(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public User GetUserByCredentials(string username, string password)
        {
            // Tìm user trong database khớp với username và password
            return _unitOfWork.Users.Find(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
    }
}

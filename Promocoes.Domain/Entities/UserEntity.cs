using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Validations;
using Promocoes.Domain.Validations.Interfaces;

namespace Promocoes.Domain.Entities
{
    public class UserEntity : BaseEntity, IValidate
    {
        public UserEntity(string name, string email, string password, string idBusiness)
        {
            IdUser = Guid.NewGuid().ToString();
            Name = name;
            Email = email;
            Password = password;
            IdBusiness = idBusiness;
        }

        public string IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdBusiness { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? VerifietAt { get; set; }

        public bool IsValid()
        {
            return new UserValidations(this)
                .GuidIsValid()
                .NameIsValid()
                .EmailIsValid()
                .NameLength()
                .PasswordLength()
                .IsValid();
        }
    }
}
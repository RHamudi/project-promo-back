using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Domain.Notifications;
using Promocoes.Domain.Validations.Interfaces;

namespace Promocoes.Domain.Validations
{
    public class UserValidations : IValidate
    {
        private readonly UserEntity _user;

        public UserValidations(UserEntity user)
        {
            _user = user;
        }

        public UserValidations GuidIsValid()
        {
            if(!Guid.TryParse(_user.IdBusiness, out Guid x))
                _user.AddNotification(new Notification("IdBusiness", "Id invalido"));

            return this;
        }

        public UserValidations NameIsValid()
        {
            if(!Regex.IsMatch(_user.Name, "^[a-zA-Z ]*$"))
                _user.AddNotification(new Notification("Name", "Não é possivel adicionar caracteres especiais"));
            
            return this;
        }

        public UserValidations EmailIsValid()
        {
            if(!Regex.IsMatch(_user.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                _user.AddNotification(new Notification("Email", "Insira um email valido"));

            return this;
        }

        public UserValidations NameLength()
        {
            if(_user.Name.Length < 3)
                _user.AddNotification(new Notification("Name", "Insira um nome maior"));
            
            return this;
        }

        public UserValidations PasswordLength()
        {
            if(_user.Password.Length < 6)
                _user.AddNotification(new Notification("Password", "Adicione uma senha maior"));

            return this;
        }

        public bool IsValid()
        {
            return _user.Notifications.Count == 0;
        }
    }
}
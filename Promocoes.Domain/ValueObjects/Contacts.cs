using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocoes.Domain.ValueObjects
{
    public class Contacts
    {
        public Contacts(string email, string number, string? site)
        {
            Email = email;
            Number = number;
            Site = site;
        }

        public string Email { get;  set; }
        public string Number { get;  set; }
        public string? Site { get;  set; }
    }
}
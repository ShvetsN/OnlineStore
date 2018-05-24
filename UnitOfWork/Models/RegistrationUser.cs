using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnitOfWork.Models
{
    public class RegistrationUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Models
{
    class UnitUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

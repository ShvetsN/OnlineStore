using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Identity
{
    public class User: IdentityUser
    {
        public string LastName { get; set; }
    }
}

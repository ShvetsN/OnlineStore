using DataLayer.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Сontexts
{
    public class UserContext:IdentityDbContext<User, UserRole, string>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}

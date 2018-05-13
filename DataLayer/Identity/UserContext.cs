using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Identity
{
    public class UserContext: IdentityDbContext<User>
    {
        public DbSet<UserProfile> Profiles { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}

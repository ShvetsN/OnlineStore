using DataLayer.Сontexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Identity
{
    public class UserDbInitializer: IUserDbInitializer
    {
        private readonly UserContext _context;

        private readonly UserManager<User> _userManager;

        private readonly RoleManager<UserRole> _roleManager;

        public UserDbInitializer(UserContext context, UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public  async Task Seed()
        {
            _context.Database.EnsureCreated();

            if ( await _roleManager.RoleExistsAsync("Administrator"))
                return;

            await _roleManager.CreateAsync(new UserRole { Name = "Administrator"});
            await _roleManager.CreateAsync(new UserRole { Name = "Manager" });
            await _roleManager.CreateAsync(new UserRole { Name = "User" });

            var admin = new User
            {
                Name = "Admin",
                LastName = "Admin",
                Email = "Admin@gmail.com",
                UserName = "Admin@gmail.com"
            };

            var adminPassword = "!Admin98";

            await _userManager.CreateAsync(admin, adminPassword);
            await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(admin.Email), "Administrator");

            var manager = new User
            {
                Name = "Manager",
                LastName = "Manager",
                Email = "Manager@gmail.com",
                UserName = "Manager@gmail.com"
            };

            var managerPassword = "!Manager98";

            await _userManager.CreateAsync(manager, managerPassword);
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(manager.Email), "Manager");
        }
    }
}

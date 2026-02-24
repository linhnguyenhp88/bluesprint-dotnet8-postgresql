using KOI.Blueprint.Domain.Entites.Users;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Infrastructure.SeedData
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;          
        }

        public async Task InitialSeedData()
        {
            if (!_userManager.Users.Any())
            {
                var assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));
                if (String.IsNullOrEmpty(assemblyPath))
                {
                    return;
                }
                   

                var rootpath = assemblyPath + @"\SeedData\SeedData.json";
                var userData = File.ReadAllText(rootpath.Replace("KOI.Blueprint.API", "KOI.Blueprint.Infrastructure"));
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                var roles = new List<Role>
                {
                    new Role {Name = "Customer", CreatedBy = "System", UpdatedBy = "System", CreatedDate = DateTime.UtcNow},
                    new Role {Name = "Admin", CreatedBy = "System", UpdatedBy = "System",CreatedDate = DateTime.UtcNow},
                    new Role {Name = "Staff", CreatedBy = "System", UpdatedBy = "System",CreatedDate = DateTime.UtcNow},
                    new Role {Name = "VIP", CreatedBy = "System", UpdatedBy = "System",CreatedDate = DateTime.UtcNow}
                };

                foreach (var role in roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role.Name))
                        await _roleManager.CreateAsync(role);
                }

                foreach (var user in users)
                {
                    user.CreatedDate = DateTime.UtcNow;
                    user.LastActive = DateTime.UtcNow;
                    await _userManager.CreateAsync(user, "Password123!");
                    await _userManager.AddToRoleAsync(user, "Customer");
                }

                var adminUser = new User
                {
                    UserName = "Admin",
                    LastActive = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "System",
                    CreatedBy = "System",
                    FullName = "Linh Nguyen",
                    City = "Zurich",
                    Country = "Switzerland",
                    Email = "system@gmail.com",
                    Status = "Active",
                    Reason = "Initial import",
                    Department = "Engineering",
                    DisplayName = "Linh"
                };

                IdentityResult result = await _userManager.CreateAsync(adminUser, "Password123!");

                if (result.Succeeded)
                {
                    var admin = await _userManager.FindByNameAsync("Admin");
                    await _userManager.AddToRolesAsync(admin, new[] { "Admin", "Staff" });
                }
            }
        }
    }
}

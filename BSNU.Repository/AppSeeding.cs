using BSNU.Core.Models;
using BSNU.Repository.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BSNU.Repository
{
    public static class AppSeeding
    {
        public static async Task SeedUsersAsync(UserManager<StaffMember> _usermanager, RoleManager<IdentityRole> _roleManager, BSNUDbContext dbContext)
        {
            if (_usermanager.Users.Count() == 0)
            {


                var roles = new List<IdentityRole>
{
    new IdentityRole { Name = "Admin" },
    new IdentityRole { Name = "DeanOfSector" },
    new IdentityRole { Name = "ProgramManager" },
    new IdentityRole { Name = "ViceDean" }
};
                foreach (var role in roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role.ToString()))
                    {
                        await _roleManager.CreateAsync(role);
                    }
                }
                // 1) Create the users
                var admin = new StaffMember { UserName = "admin@example.com", Email = "admin@example.com" };
                var dean = new StaffMember { UserName = "dean@example.com", Email = "dean@example.com" };
                var programManager = new StaffMember { UserName = "pm@example.com", Email = "pm@example.com" };
                var viceDean = new StaffMember { UserName = "vdean@example.com", Email = "vdean@example.com" };

                await _usermanager.CreateAsync(admin, "P@ssWord1");
                await _usermanager.CreateAsync(dean, "P@ssWord1");
                await _usermanager.CreateAsync(programManager, "P@ssWord1");
                await _usermanager.CreateAsync(viceDean, "P@ssWord1");

                // 2) Assign each user to its role
                await _usermanager.AddToRoleAsync(admin, "Admin");
                await _usermanager.AddToRoleAsync(dean, "DeanOfSector");
                await _usermanager.AddToRoleAsync(programManager, "ProgramManager");
                await _usermanager.AddToRoleAsync(viceDean, "ViceDean");



            }



        }
    }
}

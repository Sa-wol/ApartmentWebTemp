using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentWebTemp.Models
{
    public static class IdentityHelper
    {
        // Role names
        public const string Landlord = "Landlord";
        public const string Tenant = "Tenant";

        public static void SetIdentityOptions(IdentityOptions options)
        {
            // Setting sign in options
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            // Set password strength
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;

            // Set lockout options
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            options.Lockout.MaxFailedAccessAttempts = 5;
        }

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create role if it doesn't exist
            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if(!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        internal static async Task CreateDefaultLandlord(IServiceProvider serviceProvider)
        {
            const string email = "april@email.com";
            const string username = "landlord";
            const string password = "Apartment";

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Check if any users are in database
            if(userManager.Users.Count() == 0)
            {
                IdentityUser landlord = new IdentityUser()
                {
                    Email = email,
                    UserName = username,
                };

                // Create landlord
                await userManager.CreateAsync(landlord, password);

                // Add to landlord role
                await userManager.AddToRoleAsync(landlord, Landlord);
            }
        }
    }
}

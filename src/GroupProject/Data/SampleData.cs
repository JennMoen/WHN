using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using GroupProject.Models;

namespace GroupProject.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category()
                    {
                        Name = "Music"
                    },

                    new Category()
                    {
                        Name = "Sports"
                    },
                    new Category()
                    {
                        Name = "Family"
                    },
                    new Category()
                    {
                        Name = "Education"
                    },
                    new Category()
                    {
                        Name = "Food/Drink"
                    },
                    new Category()
                    {
                        Name = "Theater/Performing Arts"
                    },
                    new Category()
                    {
                        Name = "Art/Museums"
                    },
                    new Category()
                    {
                        Name = "Entertainment"
                    },
                    new Category()
                    {
                        Name = "Volunteer"
                    },
                    new Category()
                    {
                        Name = "Fitness"
                    },
                    new Category()
                    {
                        Name = "Nature"
                    },
                    new Category()
                    {
                        Name = "Religious"
                    },
                    new Category()
                    {
                        Name = "Clubs/Social"
                    },
                    new Category()
                    {
                        Name = "Networking"
                    }

                    );

                context.SaveChanges();

            }

        }
    }
}

using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using GroupProject.Models;
using GroupProject.Infrastructure;

namespace GroupProject.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var catRepo = serviceProvider.GetService<CategoryRepository>();

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

            context.SaveChanges();


            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category()
                    {
                        Name = "Music",
                        ImageUrl = "http://i.imgur.com/kcTS6l3.jpg"
                    },

                    new Category()
                    {
                        Name = "Sports",
                        ImageUrl = "http://i.imgur.com/0oIJisX.jpg"
                    },
                    new Category()
                    {
                        Name = "Family",
                        ImageUrl = "http://i.imgur.com/YLdg3Ed.jpg"
                    },
                    new Category()
                    {
                        Name = "Education",
                        ImageUrl = "http://i.imgur.com/lASwF1o.jpg"
                    },
                    new Category()
                    {
                        Name = "Food/Drink",
                        ImageUrl = "http://i.imgur.com/80e2fCI.jpg"
                    },
                    new Category()
                    {
                        Name = "Theater/Performing Arts",
                        ImageUrl = "http://i.imgur.com/AVXuEvl.jpg"
                    },
                    new Category()
                    {
                        Name = "Art/Museums",
                        ImageUrl = "http://i.imgur.com/fv7f1nc.jpg"
                    },
                    new Category()
                    {
                        Name = "Entertainment",
                        ImageUrl = "http://i.imgur.com/9jjjT74.jpg"
                    },
                    new Category()
                    {
                        Name = "Volunteer",
                        ImageUrl = "http://i.imgur.com/fQzec2a.jpg"
                    },
                    new Category()
                    {
                        Name = "Fitness",
                        ImageUrl = "http://i.imgur.com/bBZSm5e.jpg"
                    },
                    new Category()
                    {
                        Name = "Nature",
                        ImageUrl = "http://i.imgur.com/sA5HNVu.jpg"
                    },
                    new Category()
                    {
                        Name = "Religious",
                        ImageUrl = "http://i.imgur.com/CNQZ3SJ.jpg"
                    },
                    new Category()
                    {
                        Name = "Clubs/Social",
                        ImageUrl = "http://i.imgur.com/dB5r7aw.jpg"
                    },
                    new Category()
                    {
                        Name = "Networking",
                        ImageUrl = "http://i.imgur.com/c4ztXUP.jpg"
                    }

                );
            }

            context.SaveChanges();

            if (!context.Events.Any())
            {
                context.Events.AddRange(
                    new Event()
                    {
                        AdmissionPrice = 139.0m,
                        Category = catRepo.GetCategoryByName("Music").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 9, 3),
                        Description = "Rap/Hip-Hop Concert",
                        ImageUrl = "http://i.imgur.com/kcTS6l3.jpg",

                        Location = "Toyota Center, Tx-Houston",
                        Name = "Drake and Future",
                        Status = "public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 90.0m,
                        Category = catRepo.GetCategoryByName("Music").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 6),
                        Description = "Pop or Country",
                        ImageUrl = "http://i.imgur.com/kcTS6l3.jpg",
                        Location = "2005 Lake Robbins DriveSpring, Texas 77380 at the Cynthia Woods Pavillion TX-Spring",
                        Name = "The Dixie Chicks",
                        Status = "Public",
                        Creator = stephen
                    },

                    new Event()
                    {
                        AdmissionPrice = 30.0m,
                        Category = catRepo.GetCategoryByName("Sports").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 9, 3),
                        Description = "Football Game",
                        ImageUrl = "http://i.imgur.com/0oIJisX.jpg",
                        Location = "NRG Stadium, Houston, TX",
                        Name = "Swac Football Championship",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 8.0m,
                        Category = catRepo.GetCategoryByName("Sports").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 22),
                        Description = "Professional BaseBall Game",
                        ImageUrl = "http://i.imgur.com/0oIJisX.jpg",
                        Location = "Minute Maid park, Houston tx",
                        Name = "St. Louis Cardinals vs Houston Astros",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 13.0m,
                        Category = catRepo.GetCategoryByName("Family").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 10),
                        Description = "Come Learn About Dinosaurs at the Houston Zoo!!! prices may vary depending on age",
                        ImageUrl = "http://i.imgur.com/YLdg3Ed.jpg",
                        Location = "Brown Education center at Houston zoo 6200 Hermann Park Drive Houston, Texas 77030",
                        Name = "Dinosaurs at the Hoston Zoo",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 10.0m,
                        Category = catRepo.GetCategoryByName("Family").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 10),
                        Description = "El Centro De Coraz�n is helping families get focused on fall at their annual �Be Healthy� Family Expo & Back-to-School Fair, a wellness-centered community welcoming event held at El Centro�s Magnolia Health Center in the East End.Residents of the neighborhood and surrounding Greater Houston are invited to spend a full morning of family - friendly fun including face painting and FREE supply - stuffed backpacks for elementary - aged children.",
                        ImageUrl = "http://i.imgur.com/YLdg3Ed.jpg",
                        Location = "El Centro de Coraz�n - Magnolia Health Center - 7037 Capitol St, STE N100, Houston, TX 77011",
                        Name = "'Be Healthy' Family Expo & Back-to-School Fair in Houston",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 0m,
                        Category = catRepo.GetCategoryByName("Education").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2017, 7, 14),
                        Description = "The MLK Youth parade Will Kick-off The 2017 MLK Holiday Weekend. The Parade Will Be Held On January 14, 2017 In Houston's Midtown Originating On San Jacinto Street & Elgin Street Beginning @ 12 noon (CST). To Learn More Visit http://www.mlkgrandeparade.org Or Call 713-953-1633",
                        ImageUrl = "http://i.imgur.com/lASwF1o.jpg",
                        Location = "Orinating On San Jacinto Street & Elgin Street Houston, Texas 77004",
                        Name = "The MLK Youth parade",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 100m,
                        Category = catRepo.GetCategoryByName("Education").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 7),
                        Description = "We are pleased to Invite you to our 4 Days PMP Exam Prep training program scheduled in your city",
                        ImageUrl = "http://i.imgur.com/lASwF1o.jpg",
                        Location = "Houston, Texas, United States, Texas 77004",
                        Name = "PMP certification training",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 10m,
                        Category = catRepo.GetCategoryByName("Food/Drink").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 5),
                        Description = "1 / 3 off all bottles every Sunday",
                        ImageUrl = "http://i.imgur.com/80e2fCI.jpg",
                        Location = "2800 Kirby Cr. Ste. B-130 Houston, Texas 77098",
                        Name = "1/3 off all bottles every Sunday! in Houston",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 30.0m,
                        Category = catRepo.GetCategoryByName("Food/Drink").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 9, 12),
                        Description = "Get Crafty at the 6th annual BrewMasters Craft Beer Festival in Galveston",
                        ImageUrl = "http://i.imgur.com/80e2fCI.jpg",
                        Location = "One Hope Blvd.Galveston,Texas 77554",
                        Name = "BrewMasters Craft Beer Festival in Galveston",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 90.0m,
                        Category = catRepo.GetCategoryByName("Theater/Performing Arts").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2017, 1, 7),
                        Description = "Come Join us and experience the magic of the Disney Classic in Theatre",
                        ImageUrl = "http://i.imgur.com/AVXuEvl.jpg",
                        Location = "Hobby Center for the Performing Arts 800 Bag by Houston,Texas 77002",
                        Name = "The lion King",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 15.0m,
                        Category = catRepo.GetCategoryByName("Theater/Performing Arts").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 7),
                        Description = "Best Circus in the world",
                        ImageUrl = "http://i.imgur.com/AVXuEvl.jpg",
                        Location = "13755 S. Main St Houston,Texas 77035",
                        Name = "The univerSoul circus",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 10m,
                        Category = catRepo.GetCategoryByName("Art/Museums").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 9, 16),
                        Description = "THE PORTRAITS OF FRANZ X. WINTERHALTER",
                        ImageUrl = "http://i.imgur.com/fv7f1nc.jpg",
                        Location = "Audrey Jones Beck Building - MFAH5601 Main Street Houston, Texas 77005",
                        Name = "Franz X. Winterhalter Gallery",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 15m,
                        Category = catRepo.GetCategoryByName("Art/Museums").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 10, 8),
                        Description = "uriko Yamaguchi uses materials such as resins, wire, wood, flax, and other materials to create large-scale abstract sculptures that resonate uniquely in the spaces in which they are installed. Her spontaneous responses to architectural structures introduce a tension between the built environment and our lived experience of such spaces, emphasizing movement, color, and the play of light, which alters as the day progresses. Asia Society Texas Center architect Yoshio Taniguchi�s vision of the Fayez Sarofim Grand Hall is the ideal �palette� for Yamaguchi to use, allowing her to create ephemeral sculptures that are in direct relationship to the Texas Center�s building and the larger environment of Houston. The artist�s conceptual concerns of balancing free will with our inescapable interconnectedness, and our vulnerability to art with its powerfully transformative effects, draw viewers into sustained engagement with these wonderfully inventive and expansive expressions.Image: Yuriko Yamaguchi, Embrace (detail), 2013, Hand cast resin, stainless steel wire, and LED light, Courtesy of the artist",
                        ImageUrl = "http://i.imgur.com/fv7f1nc.jpg",
                        Location = "",
                        Name = "Yuriko Yamaguchi in Houston",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 0.0m,
                        Category = catRepo.GetCategoryByName("Entertainment").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 20),
                        Description = "If you like expertly crafted, spirit-forward cocktails and fun, this trendy industrial refuge is the place for you. House-made bitters, sodas, infusions, and liqueurs keep you feeling dapper while you indulge in some seriously heavy-handed drinks. They also have a rotating selection of hard-to-score craft brews.",
                        ImageUrl = "http://i.imgur.com/9jjjT74.jpg",
                        Location = "1424 Westheimer Rd Houston tx",
                        Name = "Anvil bar and refuge",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 0.0m,
                        Category = catRepo.GetCategoryByName("Entertainment").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 5),
                        Description = "Come enjoy the top bar in the Houston area",
                        ImageUrl = "http://i.imgur.com/9jjjT74.jpg",
                        Location = "Huston tx",
                        Name = "West Alabama Ice house",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 0m,
                        Category = catRepo.GetCategoryByName("Volunteer").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 10),
                        Description = "Sponsored by: Friends of the Houston Public Library, Minimum age: 13, Support your local library by volunteering with the Friends of the Houston Public Library at the Book Warehouse!No prior training / experience is needed; guidance will be provided at the Book Warehouse. We welcome all volunteers ages 13 and up. Please wear close - toed shoes and clothes you are comfort . . .",
                        ImageUrl = "http://i.imgur.com/fQzec2a.jpg",
                        Location = "",
                        Name = "Volunteer at Book Waregouse",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 0m,
                        Category = catRepo.GetCategoryByName("Volunteer").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 22),
                        Description = "Want to make a difference while building skills and gaining experience? Mark your calendars! The Missouri City Branch Library is holding a Service & Volunteer Fair on Saturday, August 6th at 2pm. ",
                        ImageUrl = "http://i.imgur.com/fQzec2a.jpg",
                        Location = "Missouri City Branch Library1530 Texas Parkway Missouri City,Texas 77489",
                        Name = "Service and Volunteer fair",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 90m,
                        Category = catRepo.GetCategoryByName("Fitness").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 7),
                        Description = "Learn Mixed Martial arts from the Legendary Coach Saul",
                        ImageUrl = "http://i.imgur.com/bBZSm5e.jpg",
                        Location = "3401 Gulf freeway Houston, tx",
                        Name = "Metro Fight club",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 50m,
                        Category = catRepo.GetCategoryByName("Fitness").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 5),
                        Description = "When you enter an LA Fitness, you know what to expect. The state of the art facility and equipment are familiar and comfortable, but what we are most proud of are the people who are there to serve you. The people who warmly greet you, expertly train you, enthusiastically teach you. It is the entire team, our best resource, who is dedicated to making your fitness experience an exceptional one.",
                        ImageUrl = "http://i.imgur.com/bBZSm5e.jpg",
                        Location = "2130 W Holcombe Blvd, Houston, TX 77030",
                        Name = "La fitness",
                        Status = "Public",
                        Creator = stephen
                    },
                    new Event()
                    {
                        AdmissionPrice = 10m,
                        Category = catRepo.GetCategoryByName("Nature").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 7),
                        Description = "Join a guided bird walk at Kleb Woods Nature Preserve every Wednesday morning (currently scheduled for 8:30 a.m.) plus on the first Saturday of each month at 8 a.m. Located north of Tomball this preserve features a nature center, nature trails, a wetland trail and more",
                        ImageUrl = "http://i.imgur.com/sA5HNVu.jpg",
                        Location = "Kleb Woods Nature Preserve20303 Draper Rd.Tomball,Texas 77377",
                        Name = "Weekly Birdwalk in Tomball",
                        Status = "Public",
                        Creator = mike
                    },
                    new Event()
                    {
                        AdmissionPrice = 10m,
                        Category = catRepo.GetCategoryByName("Nature").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 9),
                        Description = "The popular program is the first Saturday of each month from 10-noon, with the exception of April. The program is free with regular admission. All topics are family friendly and hands-on. Bring the family for a fun, educational morning; then stay to picnic, hike, fish or just relax�what a great way to spend a morning!",
                        ImageUrl = "http://i.imgur.com/sA5HNVu.jpg",
                        Location = "Baytown Nature Center6213 Bayway Drive Baytown,Texas 77520",
                        Name = "Nurture Nature series",
                        Status = "Public",
                        Creator = mike
                    },
                    new Event()
                    {
                        AdmissionPrice = 0.0m,
                        Category = catRepo.GetCategoryByName("Religious").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 7),
                        Description = "Come join us and experience Signs, Miracles and Wonders through the Power of the Living God.....",
                        ImageUrl = "http://i.imgur.com/CNQZ3SJ.jpg",
                        Location = "Hampton Inn Houston- Hobby Airport8620 Airport Blvd Houston, Texas 77061",
                        Name = "Sunday service",
                        Status = "Public",
                        Creator = mike
                    },
                    new Event()
                    {
                        AdmissionPrice = 0.0m,
                        Category = catRepo.GetCategoryByName("Religious").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 9),
                        Description = "Meditation is the cornerstone of Sant Mat or the Teachings of the Saints. This spiritual program through the teachings of these great Saints explores the theory and practice of meditation on inner Light and Sound and how various aspects of our life impact our spiritual growth. Each week we will explore a topic about spiritual living and meditation. During our program we will have readings, a video clip, opportunities to share insights and to ask questions, and after giving meditation instructions, we will meditate for at least 30 minutes.",
                        ImageUrl = "http://i.imgur.com/CNQZ3SJ.jpg",
                        Location = "India House, Houston, TX8888 West Bellfort Houston, Texas 77031",
                        Name = "Meditation: Enhance your Spiritual Awareness in Houston",
                        Status = "Public",
                        Creator = mike
                    },


                    new Event()
                    {
                        AdmissionPrice = 0m,
                        Category = catRepo.GetCategoryByName("Clubs/Social").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 12),
                        Description = "Its lit",
                        ImageUrl = "http://i.imgur.com/dB5r7aw.jpg",
                        Location = "Houston Tx",
                        Name = "Party at robs fam",
                        Status = "Public",
                        Creator = mike
                    },
                    new Event()
                    {
                        AdmissionPrice = 15m,
                        Category = catRepo.GetCategoryByName("Clubs/Social").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 12),
                        Description = "Party time",
                        ImageUrl = "http://i.imgur.com/dB5r7aw.jpg",
                        Location = "3222 Fondren Rd, Houston, TX 77063",
                        Name = "Club Tropicana",
                        Status = "Public",
                        Creator = mike
                    },
                    new Event()
                    {
                        AdmissionPrice = 0m,
                        Category = catRepo.GetCategoryByName("Networking").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 5),
                        Description = "N/A",
                        ImageUrl = "http://i.imgur.com/c4ztXUP.jpg",
                        Location = "Houston Tx",
                        Name = "BUSINESS & CROWDFUND EXPO BY EVERYBODY IN HOUSTON",
                        Status = "Public",
                        Creator = mike
                    },
                    new Event()
                    {
                        AdmissionPrice = 0m,
                        Category = catRepo.GetCategoryByName("Networking").First(),
                        DateCreated = new DateTime(2016, 8, 5),
                        DateOfEvent = new DateTime(2016, 8, 23),
                        Description = "YOUR NET WORTH IS YOUR NETWORK, SO COME OUT AND MEET NEW BUSINESS PROFESSIONALS IN HOUSTON!MAKE CONTACTS AND GAIN NEW LEADS.* VENUE SUBJECT TO CHANGE.",
                        ImageUrl = "http://i.imgur.com/c4ztXUP.jpg",
                        Location = "Boheme - 307 Fairview Street, Houston, TX 77006",
                        Name = "Be Social",
                        Status = "Public",
                        Creator = mike
                    }

                    );
                context.SaveChanges();

            }


        }

    }
}

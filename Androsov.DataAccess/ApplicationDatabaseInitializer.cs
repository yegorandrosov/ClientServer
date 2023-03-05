using Androsov.DataAccess.Entities;
using Androsov.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Androsov.DataAccess
{
    internal class ApplicationDatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationDatabaseInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task Initialize()
        {
            db.Database.EnsureCreated();
            await CreateUser("Desktop", "Password123");
            await CreateUser("Web", "Password456");

        }

        private async Task CreateUser(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == "Desktop");
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "Desktop",
                };

                var result = await userManager.CreateAsync(user, "Password123");

                if (!result.Succeeded)
                {
                    throw new Exception("User was not created");
                }
            }
        }
    }
}

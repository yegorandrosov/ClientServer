using Androsov.DataAccess.Entities;
using Androsov.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            //db.Database.Migrate();

            await CreateUser("Desktop", "Password123!");
            await CreateUser("Web", "Password456!");

        }

        private async Task CreateUser(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == username);
            if (user != null)
                return;

            user = new ApplicationUser()
            {
                UserName = username,
            };

            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception("User was not created");
            }
        }
    }
}

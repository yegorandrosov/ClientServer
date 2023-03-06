using Androsov.DataAccess.Entities;
using Androsov.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Androsov.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MessageRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<string?> Get(string username)
        {
            return dbContext.Messages
                .Where(x => x.User.UserName == username)
                .Select(x => x.Text)
                .FirstOrDefaultAsync();
        }

        public async Task Set(string username, string text)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.UserName == username);

            if (user == null)
            {
                throw new ArgumentException("Invalid username", nameof(username));
            }

            var message = new Message()
            {
                CreatedDate = DateTime.UtcNow,
                Text = text,
                UserId = user.Id,
            };

            dbContext.Messages.Add(message);
            await dbContext.SaveChangesAsync();
        }
    }
}

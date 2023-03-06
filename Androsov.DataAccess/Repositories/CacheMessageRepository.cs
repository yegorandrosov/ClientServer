using Androsov.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Androsov.DataAccess.Repositories
{
    public class CacheMessageRepository : IMessageRepository
    {
        private readonly MessageRepository messageRepository;
        private readonly ICacheService cache;

        public CacheMessageRepository(MessageRepository messageRepository, ICacheService cache) 
        {
            this.messageRepository = messageRepository;
            this.cache = cache;
        }

        public async Task<string?> Get(string username)
        {
            if (cache.TryGet(username, out string? message))
                return message;

            message = await messageRepository.Get(username);

            cache.Set(username, message);

            return message;
        }

        public async Task Set(string username, string message)
        {
            await messageRepository.Set(username, message);
            cache.Set(username, message);
        }
    }
}

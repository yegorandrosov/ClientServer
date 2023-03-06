using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Androsov.DataAccess.Interfaces
{
    public interface IMessageRepository
    {
        public Task<string?> Get(string username);
        public Task Set(string username, string message);
    }
}

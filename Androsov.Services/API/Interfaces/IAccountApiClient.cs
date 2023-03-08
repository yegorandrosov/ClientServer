using Androsov.API.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Androsov.Services.API.Interfaces
{
    public interface IAccountApiClient
    {
        public Task<AuthResponse> Login();
    }
}

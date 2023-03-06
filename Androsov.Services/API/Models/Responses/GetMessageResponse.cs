using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Androsov.Services.API.Models.Responses
{
    public class GetMessageResponse
    {
        public bool IsSuccess { get; set; }

        public string? Message { get; set; }
    }
}

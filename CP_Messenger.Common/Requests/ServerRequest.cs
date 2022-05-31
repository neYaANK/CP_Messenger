using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Requests
{
    public abstract class ServerRequest
    {
        public ServerRequest(RequestType type) { Type = type; }
        public RequestType Type { get; set; }
    }
}

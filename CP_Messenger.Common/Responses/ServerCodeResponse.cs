using CP_Messenger.Common.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Responses
{
    public class ServerCodeResponse : ServerRequest
    {
        public ServerCodeResponse() : base(RequestType.ActionCode){}
        public ServerCodeResponse(RequestType type) : base(type){}
        public ServerCodeResponse(string code,string description) : base(RequestType.ActionCode)
        {
            Code = code;
            Description = description;
        }
        public ServerCodeResponse(string code,string description,RequestType type) : base(type)
        {
            Code = code;
            Description = description;
        }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}

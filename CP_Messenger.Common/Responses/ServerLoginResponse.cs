using CP_Messenger.Common.Model;
using CP_Messenger.Common.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Responses
{
    public class ServerLoginResponse : ServerCodeResponse
    {
        public ServerLoginResponse() : base(RequestType.Login){}
        public ServerLoginResponse(User userData, string code, string message) : base(code, message, RequestType.Login)
        {
            UserData = userData;
        }        
        public User UserData { get; set; }
    }
}

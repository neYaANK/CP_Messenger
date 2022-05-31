using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Requests
{
    public class ServerLoginRequest : ServerRequest
    {
        public ServerLoginRequest() : base(RequestType.Login){}
        public ServerLoginRequest(string login, string password) : base(RequestType.Login) { Login = login; Password = password; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}

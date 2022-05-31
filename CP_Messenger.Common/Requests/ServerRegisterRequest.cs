using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Requests
{
    public class ServerRegisterRequest : ServerRequest
    {
        public ServerRegisterRequest() : base(RequestType.Register) { }
        public ServerRegisterRequest(string login,string password,string name,string surname) : base(RequestType.Register) 
        {
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;
        }
        
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

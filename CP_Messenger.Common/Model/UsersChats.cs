using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Model
{
    public class UsersChats
    {
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ChatRole Role { get; set; }
    }
}

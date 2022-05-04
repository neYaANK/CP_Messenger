using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Model
{
    public class Contact
    {
        public User Owner{ get; set; }
        public User Changed{ get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public User Owner{ get; set; }
        public int OwnerId { get; set; }
        public User Changed{ get; set; }
        public int ChangedId { get; set; }
        public string Name { get; set; }

    }
}

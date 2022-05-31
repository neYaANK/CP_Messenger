using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Model
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public User Sender { get; set; }
        public int SenderId { get; set; }
        public MessageType Type { get; set; }
        public string Value { get; set; }
        [NotMapped]
        public byte[] ValueToByte { get => Convert.FromBase64String(Value); }
        public Chat Chat { get; set; }
    }
}

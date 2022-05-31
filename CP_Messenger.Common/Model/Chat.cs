using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Model
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public SmallImage ChatImage { get; set; }
        public List<Message> Messages { get; set; }
        public List<UsersChats> UsersChats{ get; set; }
        
        [NotMapped]
        public string LastMessage { get {
                var last = Messages.Last();
                if (last.Type == MessageType.File) return "File";
                else if (last.Type == MessageType.Image) return "Image";
                else return last.Value.Substring(0, last.Value.Length - 1 > 20 ? 20 : last.Value.Length - 1);
            }}
    }
}

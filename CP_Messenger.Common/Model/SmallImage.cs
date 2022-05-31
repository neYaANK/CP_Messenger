using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Model
{
    public class SmallImage
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
}

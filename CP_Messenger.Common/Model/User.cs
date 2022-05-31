using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_Messenger.Common.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserCredential Credential { get; set; }
        public int CredentialId { get; set; }
        public SmallImage ProfilePicture { get; set; }
        public int ProfilePictureId { get; set; }
        public List<UsersChats> UsersChats { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}

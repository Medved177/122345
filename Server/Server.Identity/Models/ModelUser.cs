using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Identity.Models
{
    public class ModelUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public string Mname { get; set; }
        public int Year { get; set; }
    }
}

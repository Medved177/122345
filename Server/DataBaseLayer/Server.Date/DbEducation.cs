using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Data
{
    public class DbEducation
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string University { get; set; }
        public string Specialty { get; set; }
        public string View { get; set; }
        public DbEmployee Employee { get; set; }
    }
}

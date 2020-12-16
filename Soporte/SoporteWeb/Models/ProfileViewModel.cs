using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoporteWeb.Models
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Hobbies { get; set; }
        public string Musics { get; set; }
        public string Videos { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
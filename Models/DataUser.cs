using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_App.Models
{
    public class DataUser:IdentityUser
    {
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Snippet> Snippets { get; set; }
    }
}

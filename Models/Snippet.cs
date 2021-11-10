using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_App.Models
{
    public class Snippet
    {
        
        private static IList<string> langs = Array.AsReadOnly(new string[]{
            "C#", "JS", "Java", "Python"
        });
        public static IList<string> Langs { get; } = langs;

        public int Id { get; set; }
        
        [MaxLength(80), Required]
        public string Title { get; set; }
        
        [MaxLength(1000)]
        public string Description { get; set; }
        
        [Required]
        public string Content { get; set; }

        [Required]
        public string Lang { get; set; }
        
        public string UserId { get; set; }
        public DataUser User { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }


}

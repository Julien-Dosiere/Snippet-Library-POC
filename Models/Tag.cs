using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_App.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        public DataUser User { get; set; }

        public ICollection<Snippet> Snippets { get; set; }


    }
}
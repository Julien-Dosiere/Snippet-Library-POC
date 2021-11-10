using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_App.Models
{
    public class SearchQuery
    {
        public string SearchTerm { get; set; }

        public string Lang { get; set; }

        public int Type{ get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}

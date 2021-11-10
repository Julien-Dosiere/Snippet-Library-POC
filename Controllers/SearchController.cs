using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_App.Data;
using MVC_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_App.Controllers
{
    public class SearchController : Controller
    {
        public ApplicationDbContext _context{ get; set; }

        private Dictionary<int, string> types = new Dictionary<int, string>()
        {
            {1,  "Titles & Descriptions"},
            {2,  "Code"},
        };
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        async public Task<IActionResult> Search()
        {
            ViewData["Langs"] = new SelectList(Snippet.Langs);
            ViewBag.tags = new List<Tag>(_context.Tags);
            ViewData["searchTypes"] = new SelectList(types, "Key", "Value");
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> Search(SearchQuery searchQuery)
        {
            
            return View();
        }


    }
}

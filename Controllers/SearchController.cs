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
        public ApplicationDbContext _context { get; set; }

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

            var form = HttpContext.Request.Form;




            List<int> searchedTagsIds = new List<int>();
            foreach (var input in form)
            {
                if (input.Key.Contains("tag"))
                {
                    int tagId = Int32.Parse(input.Key.Substring(4));
                    searchedTagsIds.Add(tagId);
                }
            }


            IQueryable<Snippet> datas = null;

            if (searchQuery.SearchTerm != null)
            {
                if (searchQuery.Type == 1)
                    datas = _context.Snippets
                        .Where(snippet => snippet.Tags.Any(tag => searchedTagsIds.Contains(tag.Id)))
                        .Where(snippet => (
                               snippet.Lang == searchQuery.Lang && (
                               snippet.Title.ToLower().Contains(
                                   searchQuery.SearchTerm.ToLower()) || 
                                   snippet.Description.ToLower().Contains(searchQuery.SearchTerm.ToLower()))
                       ));
                else
                    datas = _context.Snippets
                        .Where(snippet => snippet.Tags.Any(tag => searchedTagsIds.Contains(tag.Id)))
                        .Where(snippet => (
                                    snippet.Lang == searchQuery.Lang &&
                                    snippet.Content.ToLower().Contains(searchQuery.SearchTerm.ToLower())
                       ));
            }
            else
            {

                // datas = _context.Snippets.Where(snippet => searchedTagsIds.All(requiredId => snippet.Tags.Any(tag => requiredId == tag.Id)));

                //datas = from snippet in _context.Snippets
                //        from tag in snippet.Tags
                //        where searchedTagsIds.Any(t => t == tag.Id)
                //        select snippet;
                //datas = _context.Snippets.Where(snippet => snippet.Tags.All(tag => searchedTagsIds.Contains(tag.
                //    Id))).Where(snippet => snippet.Lang == searchQuery.Lang);


                datas = _context.Snippets
                    .Where(snippet => (snippet.Tags.Any(tag => searchedTagsIds.Contains(tag.Id))))
                    .Where(snippet => snippet.Lang == searchQuery.Lang);

            }
                ViewBag.Snippets = datas.ToList();


                ViewData["Langs"] = new SelectList(Snippet.Langs);
                ViewBag.tags = new List<Tag>(_context.Tags);
                ViewData["searchTypes"] = new SelectList(types, "Key", "Value");
                return View();
            

        }


    }
}

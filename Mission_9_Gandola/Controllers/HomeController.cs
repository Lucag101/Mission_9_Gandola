using Microsoft.AspNetCore.Mvc;
using Mission_9_Gandola.Models;
using Mission_9_Gandola.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_Gandola.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        
        //private BookstoreContext context { get; set; }
        //public HomeController(BookstoreContext temp) => context = temp;
        
        public IActionResult Index(int pageNum = 1)
        {
            int numResults = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                    .OrderBy(p => p.Title)
                    .Skip(numResults * (pageNum - 1))
                    .Take(numResults),

                PageInfo = new PageInfo
                {
                    TotalBooks = repo.Books.Count(),
                    BooksPerPage = numResults,
                    CurrentPage = pageNum
                }
            };


            //var con = repo.Books
            //    .OrderBy(p => p.Title)
            //    .Skip(numResults * (pageNum-1))
            //    .Take(numResults)
            //    ;
            return View(x);
        }
    }

}

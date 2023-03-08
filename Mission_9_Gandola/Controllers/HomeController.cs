using Microsoft.AspNetCore.Mvc;
using Mission_9_Gandola.Models;
using Mission_9_Gandola.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_Gandola.Controllers
{
    //main home controller
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        
        //private BookstoreContext context { get; set; }
        //public HomeController(BookstoreContext temp) => context = temp;
        
        //method that allows page variability and pagination
        public IActionResult Index( string category, int pageNum = 1)
        {
            int numResults = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                    .Where(p => p.Category == category || category == null)
                    .OrderBy(p => p.Title)
                    .Skip(numResults * (pageNum - 1))
                    .Take(numResults),

                PageInfo = new PageInfo
                {
                    // TotalBooks should only count all books, if cateogyr is null. Check.
                    TotalBooks =  (category == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(x => x.Category == category).Count()),
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

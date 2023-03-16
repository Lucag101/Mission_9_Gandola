using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission_9_Gandola.Infrastructures;
using Mission_9_Gandola.Models;
using Mission_9_Gandola.Models.ViewModels;

namespace Mission_9_Gandola.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public PurchaseModel (IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            
            //cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(b, 1);

            //HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Mission_9_Gandola.Models;
using Mission_9_Gandola.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_Gandola.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; } 
        private Cart cart { get; set; }
        public PurchaseController(IPurchaseRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }
        
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            //Created entry in database for personal info and address
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry but your cart is empty *cough, cough, idiot*");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = cart.Items.ToArray();
                repo.SavePurchase(purchase);
                cart.ClearCart();
                return RedirectToPage("/post_purchase");
            }
            else
            {
                return View();
            }
        }
    }
}

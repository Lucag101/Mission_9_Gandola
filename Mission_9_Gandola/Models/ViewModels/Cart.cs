using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_Gandola.Models.ViewModels
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();
        public void AddItem(Books book, int qty)
        {
            CartLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
       // make this function add up all the costs of of books in cart
       // something like a for loop that adds costs (total += x.Quantity)
        public double CalculateTotal()
        {
            double sum = 0;
            foreach (var i in Items)
            {
                sum += i.Quantity * i.Book.Price;
            }
            return sum;
        }
    }

   
    public class CartLineItem
    {
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
        
    }
}

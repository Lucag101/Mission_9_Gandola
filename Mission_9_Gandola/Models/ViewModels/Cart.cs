using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_Gandola.Models.ViewModels
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();
        public virtual void AddItem(Books book, int qty)
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
        //if we want to remove books, use RemoveItem function
        public virtual void RemoveItem(Books book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }
         public virtual void ClearCart()
        {
            Items.Clear();
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
        [Key]
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
    }
}

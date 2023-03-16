using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mission_9_Gandola.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_Gandola.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }
        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }
        [Required(ErrorMessage = "You must enter a name:")]
        public string Name { get; set; }
        [Required(ErrorMessage ="You must enter address:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage ="You must enter City:")]
        public string City { get; set; }
        [Required(ErrorMessage ="You must enter a state:")]
        public string Zip { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "You must enter a country:")]
        public string Country { get; set; }
        public bool Anonymous { get; set; }

    }
}

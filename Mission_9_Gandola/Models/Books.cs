using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission_9_Gandola.Models
{
    public partial class Books
    {
        [Key]
        [Required]
        public long BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Isbn { get; set; }
        public string Classification { get; set; }
        public string Category { get; set; }
        public long PageCount { get; set; }
        public double Price { get; set; }
    }
}

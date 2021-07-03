using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Pages.Model
{
    public class Book
    {
        // Creating BookID
        [Key]
        public int CreateID { get; set; }

        // Creating BookName
        [Required]
        public string BookName { get; set; }

        // Creating BookAuthor
        [Required]
        public string Author { get; set; }

        // Creating BookGenre
        [Required]
        public string BookGenre { get; set; }
    }
}

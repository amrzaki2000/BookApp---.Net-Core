using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Pages.Model
{
    public class Book
    {
        [Key]
        public int CreateID { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string Author { get; set; }
        [Required]
        public string BookGenre { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Pages.BookLList
{
    public class IndexModel : PageModel
    {
        // Use dependancy Injection
        private readonly dbHandler db;

        //Create a constructor to intialize dbHandler variable
        public IndexModel(dbHandler db)
        {
            this.db = db;
                
        }
        
        //Create IEnumerable interface to store Books Collection
        public IEnumerable<Book> Books { get; set; }


        // Get the books stored in the database
        public async Task OnGet()
        {
            Books = await db.Book.ToListAsync();  //Returns the books stored in the database
        }


        // Function to delete book from the database
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            db.Remove(book);
            await db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

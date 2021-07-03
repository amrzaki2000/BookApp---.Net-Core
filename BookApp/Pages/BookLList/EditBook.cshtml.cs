using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookApp.Pages.BookLList
{
    public class EditBookModel : PageModel
    {
        // Use dependancy Injection
        private readonly dbHandler db;

        //Create a constructor to intialize dbHandler variable
        public EditBookModel(dbHandler db)
        {
            this.db = db;

        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await db.Book.FindAsync(id);

        }

        // Add book to the database when data is posted to the page
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {  
                // Updating BookInfo
                var BookDB = await db.Book.FindAsync(Book.CreateID);
                BookDB.BookName = Book.BookName;
                BookDB.Author = Book.Author;
                BookDB.BookGenre = Book.BookGenre;

                //Updat Changes
                await db.SaveChangesAsync();

                return Redirect("Index");
            }
            else
            {
                return Page();                  //If state is not valid, stay at the same page
            }
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookApp.Pages.BookLList
{
    public class CreateBookModel : PageModel
    {
        // Use dependancy Injection
        private readonly dbHandler db;

        //Create a constructor to intialize dbHandler variable
        public CreateBookModel(dbHandler db)
        {
            this.db = db;

        }

        [BindProperty]
        public Book Book { get; set; }
        
        // Add book to the database when data is posted to the page
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await db.AddAsync(Book);                      //Creating the book
                await db.SaveChangesAsync();               //Pushing changes to the database
                return Redirect("Index");                //Redirect back to BooksList page
            }
            else
            {
                return Page();                  //If state is not valid, stay at the same page
            }
        }
        
        public void OnGet()
        {

        }
    }
}

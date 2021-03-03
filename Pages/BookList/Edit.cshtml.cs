using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book book { get; set; }

        public async Task OnGet(int id)
        {
            book = await _db.Book.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromdb = await _db.Book.FindAsync(book.Id);
                BookFromdb.Name = book.Name;
                BookFromdb.Auther = book.Auther;
                BookFromdb.ISBN = book.ISBN;
                await _db.SaveChangesAsync();

               return RedirectToPage("Index");
            }
            return RedirectToPage("Index");
        }
    }
}

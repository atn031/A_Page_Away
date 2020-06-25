using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APageAway.Model;

namespace APageAway.Pages.ProjectPages
{
    public class IndexModel : PageModel
    {
        //In order to retrieve the information from the database, we need DBContext. Since it has been added to the pipeline we can access it.
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;
        public IndexModel(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IEnumerable<Book> Books { get; set; }
       
        
        public async Task OnGet()
        {
            //going to the database and retrieving all the books. Then storing all the info, in the IEnumerable Books. 
            //The view will already have all the data ready to display. 
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }

            if(book.ImageId != null)
            {
                var fullPath = Path.Combine(_env.ContentRootPath, "wwwroot/bookImages", book.ImageId);

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }

            _db.Book.Remove(book);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
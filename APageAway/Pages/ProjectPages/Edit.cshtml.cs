using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using APageAway.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace APageAway.Pages.ProjectPages
{
    public class EditModel : PageModel
    {
        //I'll need to update the database
        private ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;
        public EditModel(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [BindProperty] //allows me to access the values entered in the view in the OnPost Method
        public Book Book { get; set; }
        public IFormFile UploadedBookImage { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.Author = Book.Author;
                BookFromDb.CurrentChapter = Book.CurrentChapter;
                BookFromDb.TotalChapters = Book.TotalChapters;
                BookFromDb.Status = Book.Status;
                BookFromDb.Artist = Book.Artist;
                BookFromDb.Comments = Book.Comments;

                if (UploadedBookImage != null)
                {
                    var file = Path.Combine(_env.ContentRootPath, "wwwroot/bookImages", UploadedBookImage.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await UploadedBookImage.CopyToAsync(fileStream);
                        Book.ImageId = UploadedBookImage.FileName;
                        BookFromDb.ImageId = Book.ImageId;
                    }
                }

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using APageAway.Model;

namespace APageAway.Pages.ProjectPages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;

        public CreateModel(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        [BindProperty]
        public Book Book { get; set; }
        public IFormFile UploadedBookImage { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                if(UploadedBookImage != null)
                {
                    var file = Path.Combine(_env.ContentRootPath, "wwwroot/bookImages", UploadedBookImage.FileName);

                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await UploadedBookImage.CopyToAsync(fileStream);
                        Book.ImageId = UploadedBookImage.FileName;
                    }
                }


               await _db.Book.AddAsync(Book);
               await _db.SaveChangesAsync();
               return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
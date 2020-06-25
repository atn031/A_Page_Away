using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APageAway.Model
{
    public class Book
    {
        [Key]//This will be a unique key to identity the book
        public int Id { get; set; }

        [Required] //Name cannot be null
        public string Name { get; set; }
        [Required] //Author cannot be null
        public string Author { get; set; }
        public string Artist { get; set; }
        public string Comments { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Only positive numbers can be entered")]
        public int CurrentChapter { get; set; }
        [Range(0, int.MaxValue, ErrorMessage="Only positive numbers can be entered")]
        public int TotalChapters { get; set; }
        public string ImageId { get; set; }
        public string Status { get; set; }
    }
}

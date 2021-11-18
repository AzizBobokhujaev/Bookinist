using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinist.Models.Entity
{
    public class BookDTO
    {
        public int Id { get; set; }
        [Display(Name = "Имя книги")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Имя автора")]
        [Required]
        public string Author { get; set; }
        [Display(Name = "Цена")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Краткое описание ")]
        [Required]
        public string ShortDesc { get; set; }
        [Display(Name = "Полное описание")]
        [Required]
        public string LongDesc { get; set; }
        [Display(Name = "Категория")]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageName { get; set; }
        [Display(Name ="Image")]
        public IFormFile ImageFile { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string UserName { get; set; }


    }
}

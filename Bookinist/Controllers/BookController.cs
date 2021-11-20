using Bookinist.Context;
using Bookinist.Models.DTO;
using Bookinist.Models.Entity;
using Bookinist.Services.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bookinist.Controllers
{
    public class BookController:Controller
    {
        private readonly BookinistContext _bookinistContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly BookService _bookService;

        public BookController(BookinistContext bookinistContext, IWebHostEnvironment webHostEnvironment, BookService bookService)
        {
            _bookinistContext = bookinistContext;
            _webHostEnvironment = webHostEnvironment;
            _bookService = bookService;
        }

        [Authorize]
        [NonAction]
        private async Task<string> CreateImage(IFormFile imageFile)
        {
            if (imageFile == null) return null;

            var rootPath = _webHostEnvironment.WebRootPath;
            var filename = Path.GetFileNameWithoutExtension(imageFile.FileName); //02animalpicture
            var fileExtension = Path.GetExtension(imageFile.FileName); //.jpeg
            var finalFileName = $"{filename}_{DateTime.Now.ToString("yyMMddHHmmssff")}{fileExtension}";
            var filePath = Path.Combine(rootPath, "images", finalFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return finalFileName;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var bookDTO = new BookDTO();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var categories = await _bookinistContext.Categories.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToListAsync();

            bookDTO.Categories = categories;

            return View(bookDTO);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(BookDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string finalFileName = null;
            if (model.ImageFile != null)
            {
                finalFileName = await CreateImage(model.ImageFile);
            }

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var book = new Book
            {
                Name = model.Name,
                Author = model.Author,
                Price = model.Price,
                Image = finalFileName,
                CategoryId = model.CategoryId,
                ShortDesc = model.ShortDesc,
                LongDesc = model.LongDesc,
                UserId = int.Parse(currentUserId),
                CreatedAt = DateTime.Now
            };
            _bookinistContext.Books.Add(book);
            await _bookinistContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetById(id);
            return View(book);
        }

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Edit(BookDTO model)
        //{

        //}
    }
}

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

        public BookController(BookinistContext bookinistContext)
        {
            _bookinistContext = bookinistContext;
            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var book = new BookDTO
            {
                Categories = await _bookinistContext
                    .Categories
                    .Select(p=> new SelectListItem { Value = p.Id.ToString(),Text =p.Name}).ToListAsync()
            };

            return View(book);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(BookDTO model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _bookinistContext
                    .Categories
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToListAsync();
                return View(model);
            }

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var book = new Book
            {
                Name = model.Name,
                Author = model.Author,
                Price = model.Price,
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
            var book = await _bookinistContext.Books.FindAsync(id);
            if (book==null)
            {
                return RedirectToAction("Index", "Home");
            }
            var result = new BookDTO
            {   
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Price = book.Price,
                ShortDesc = book.ShortDesc,
                LongDesc = book.LongDesc,
                UserId = book.UserId,
                CategoryId = book.CategoryId,
                Categories = await _bookinistContext.Categories
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToListAsync()
            };
            return View(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(BookDTO model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _bookinistContext.Categories
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToListAsync();
                return View(model);
            }

            var book = await _bookinistContext.Books.FindAsync(model.Id);
            if (book == null)
            {
                return RedirectToAction("Index", "Index");
            }

            book.Name = model.Name;
            book.Author = model.Author;
            book.Price = model.Price;
            book.ShortDesc = model.ShortDesc;
            book.LongDesc = model.LongDesc;
            book.CategoryId = model.CategoryId;
            book.UserId = model.UserId;

            await _bookinistContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

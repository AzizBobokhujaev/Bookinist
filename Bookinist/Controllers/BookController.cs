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
using System.Threading;
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


            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookinistContext.Books.FindAsync(id);
            if (book==null)
            {
                return RedirectToAction("Index");
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
        public async Task<IActionResult> Edit(BookDTO model, CancellationToken token)
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
                return RedirectToAction("Index");
            }

            book.Name = model.Name;
            book.Author = model.Author;
            book.Price = model.Price;
            book.ShortDesc = model.ShortDesc;
            book.LongDesc = model.LongDesc;
            book.CategoryId = model.CategoryId;

            await _bookinistContext.SaveChangesAsync(token);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookinistContext.Books.FindAsync(id);
            if (book == null)
            {
                RedirectToAction("Privacy","Home");
            }
            _bookinistContext.Remove(book);
            await _bookinistContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index(int categoryId)
        {
            var result = _bookinistContext.Books.AsQueryable();

            if (categoryId>0)
            {
                result = result.Where(p => p.CategoryId == categoryId).AsQueryable();
            }

            var bookList = new List<BookDTO>();
            foreach (var book in await result.ToListAsync())
            {
                bookList.Add(new BookDTO
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Price = book.Price,
                    ShortDesc = book.ShortDesc,
                    LongDesc = book.LongDesc,
                    CategoryId = book.CategoryId,
                    CategoryName = book.Category.Name,
                    UserId = book.UserId,
                    UserName = book.User.UserName
                });
            }
            return View(bookList);

        }
    }
}

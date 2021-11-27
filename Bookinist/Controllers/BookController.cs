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
        public async Task<IActionResult> Home()
        {
            var books = await GetAll();
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> GetMyBooks()
        {
            var books = await GetMyBook();
            
            return View(books);

        }
        [NonAction]
        public async Task<List<BookDTO>> GetMyBook()
        {
            var book = await _bookinistContext.Books.Select(p => new BookDTO
            {
                Id = p.Id,
                Name = p.Name,
                Author = p.Author,
                Price = p.Price,
                ShortDesc = p.ShortDesc,
                LongDesc = p.LongDesc,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Status = p.Status,
                UserId = p.UserId,
                UserName = p.User.UserName,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).Where(p =>  p.UserName == User.Identity.Name).ToListAsync();
            return book;
        }
        [NonAction]
        public async Task<List<BookDTO>> GetAll()
        {
            var book = await _bookinistContext.Books.Select(p => new BookDTO
            {
                Id = p.Id,
                Name = p.Name,
                Author = p.Author,
                Price = p.Price,
                ShortDesc = p.ShortDesc,
                LongDesc = p.LongDesc,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Status = p.Status,
                UserId = p.UserId,
                UserName = p.User.UserName,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).Where(p=>p.Status==true).ToListAsync();
            return book;
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
                Status = false,
                UserId = int.Parse(currentUserId),
                CreatedAt = DateTime.Now
            };

            _bookinistContext.Books.Add(book);
            await _bookinistContext.SaveChangesAsync();


            return RedirectToAction("Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookinistContext.Books.FindAsync(id);
            if (book==null)
            {
                return RedirectToAction("Home");
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
                Status = book.Status,
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
                return RedirectToAction("Home");
            }

            book.Name = model.Name;
            book.Author = model.Author;
            book.Price = model.Price;
            book.ShortDesc = model.ShortDesc;
            book.LongDesc = model.LongDesc;
            book.CategoryId = model.CategoryId;
            if (User.IsInRole("Admin"))
            {
                book.Status = model.Status;
            }
            else
            {
                book.Status = false;
            }
            book.UpdatedAt = DateTime.Now;

            await _bookinistContext.SaveChangesAsync(token);

            if (User.IsInRole("User"))
            {
                return RedirectToAction("GetMyBooks");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookinistContext.Books.FindAsync(id);
            if (book == null)
            {
                RedirectToAction("Home");
            }
            _bookinistContext.Remove(book);
            await _bookinistContext.SaveChangesAsync();
            return RedirectToAction("Home");
        }
        [HttpGet]
        public async Task<IActionResult> Index(int categoryId)
        {
            var books = await GetForView();
            return View(books);
        }
        [NonAction]
        public async Task<List<BookDTO>> GetForView()
        {
            var book = await _bookinistContext.Books.Select(p => new BookDTO
            {
                Id = p.Id,
                Name = p.Name,
                Author = p.Author,
                Price = p.Price,
                ShortDesc = p.ShortDesc,
                LongDesc = p.LongDesc,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Status = p.Status,
                UserId = p.UserId,
                UserName = p.User.UserName,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToListAsync();
            return book;
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookinistContext.Books.FindAsync(id);
            if (book == null)
            {
                return RedirectToAction("Home");
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
                Status = book.Status,
                CategoryId = book.CategoryId,
                Categories = await _bookinistContext.Categories
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToListAsync()
            };
            return View(result);
        }

    }
}

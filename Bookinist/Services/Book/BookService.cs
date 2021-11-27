using AutoMapper;
using Bookinist.Context;
using Bookinist.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookinist.Models.DTO;

namespace Bookinist.Services.Book
{
    public class BookService
    {
        private readonly BookinistContext _context;
        private readonly IMapper _mapper;

        public BookService(BookinistContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> GetAll()
        {
            var books = await _context.Books.Select(m => new BookDTO
            {
                Id = m.Id,
                Name = m.Name,
                Author = m.Author,
                ShortDesc = m.ShortDesc,
                LongDesc = m.LongDesc,
                Price = m.Price,
                ImageName = m.Image,
                CategoryId = m.CategoryId,
                CategoryName = m.Category.Name,
                UserId = m.User.Id,
                UserName = m.User.UserName,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt

            }).ToListAsync();
            return books;
        }

        public async Task<BookDTO> GetById(int id)
        {
            if (id == 0)
            {
                throw new Exception("Book with this id not found");

            }

            var book = await _context.Books.FirstOrDefaultAsync(p => p.Id == id);

            if (book ==null)
            {
                throw new Exception("Book with this id not found");
            }

            var bookDTO = _mapper.Map<BookDTO>(book);

            bookDTO.Categories = await _context.Categories.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToListAsync();

            return bookDTO;
        }
        public async Task Update(BookDTO model, string fileName)
        {
            var book = _mapper.Map<Bookinist.Models.Entity.Book>(model);
            book.Image = string.IsNullOrEmpty(fileName) ? book.Image : fileName;

            book.UpdatedAt = DateTime.Now.ToString();
            _context.Books.Update(book);

            await _context.SaveChangesAsync();

        }
    }
}

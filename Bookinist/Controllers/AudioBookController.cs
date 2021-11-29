using Bookinist.Context;
using Bookinist.Models.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bookinist.Controllers
{
    public class AudioBookController : Controller
    {
        private  readonly BookinistContext _context;
        private IWebHostEnvironment _env;
        public AudioBookController(BookinistContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var audiobook = await _context.AudioBooks.Select(p => new AudioBook
            {
                Id = p.Id,
                Name = p.Name,
                PathVal = p.PathVal,
                UserId = p.User.Id,
                Description= p.Description,
                CreatedAt = p.CreatedAt
            }).ToListAsync();
            return View(audiobook);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( AudioBook model, IFormFile file)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string fileName = DateTime.Now.ToString("dd/MM/yy/HH/mm/ss") + ".mp3";
            var dir = _env.WebRootPath;
            var fullpath = Path.Combine(dir, "Music", fileName);

            using (var fileStream = new FileStream(Path.Combine(dir, "Music", fileName), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            

            //Это создает экземпляр нашей модели песни, сохраняет его как переменную и сохраняет в базе данных
            var song = new AudioBook {
                Name = model.Name,
                UserId=int.Parse(currentUserId),
                PathVal = fullpath,  
                Description = model.Description,
                CreatedAt = DateTime.Now.ToString("dd/MM/yy/HH/mm/ss")
            };

            _context.AudioBooks.Add(song);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var song = await _context.AudioBooks.FindAsync(id);
            _context.AudioBooks.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// ///////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.AudioBooks.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PathVal,Description,CreatedAt")] AudioBook song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }


    }
}

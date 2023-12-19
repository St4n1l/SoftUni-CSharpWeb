using Library.Data;
using Library.Data.Entities;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly LibraryDbContext dbContext;

        public BookController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task<IActionResult> All()
        {
            var model = await GetAllBooksAsync();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await GetMyBooksAsync(GetUserId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await GetAddBookAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await AddBookAsync(model);
            return RedirectToAction("All", "Book");
        }

        private async Task AddBookAsync(AddBookViewModel model)
        {
            var book = new Book()
            {
                Author = model.Author,
                Title = model.Title,
                Description = model.Description,
                Rating = model.Rating,
                ImageUrl = model.Url,
                CategoryId = model.CategoryId
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        private async Task<AddBookViewModel> GetAddBookAsync()
        {
            var categories = await dbContext.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();

            var model = new AddBookViewModel()
            {
                Categories = categories
            };


            return model;
        }

        private async Task<IEnumerable<MyBookViewModel>> GetMyBooksAsync(string userId)
        {
            
            return await dbContext.UsersBooks.Where(ub => ub.CollectorId == userId).Select(ub =>
                new MyBookViewModel()
                {
                    Author = ub.Book.Author,
                    Category = ub.Book.Category.Name,
                    Description = ub.Book.Description,
                    Id = ub.Book.Id,
                    ImageUrl = ub.Book.ImageUrl,
                    Title = ub.Book.Title,
                }).ToListAsync();
        }




        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await this.dbContext.Books.Select(b => new AllBookViewModel()
            {
                Id = b.Id,
                Author = b.Author,
                Category = b.Category.Name,
                Description = b.Description,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl,

            }).ToListAsync();
        }
    }
}

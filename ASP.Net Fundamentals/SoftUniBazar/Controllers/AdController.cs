using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Entities;
using SoftUniBazar.Models;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext dbContext;

        public AdController(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> All()
        {
            var adViewModels = await dbContext.Ads
                .Select(ad => new AdAllViewModel
                {
                    Id = ad.Id,
                    AddedOn = ad.CreatedOn,
                    Category = ad.Category.Name,
                    Description = ad.Description,
                    Price = ad.Price,
                    Owner = ad.Owner.UserName,
                    Name = ad.Name
                }).ToListAsync();


            return View(adViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var adViewModel = new AdFormViewModel
            {
                Categories = await dbContext.Categories.Select(cat => new CategoryViewModel
                {
                    Id = cat.Id,
                    Name = cat.Name
                }).ToListAsync()
            };

            return View(adViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AdFormViewModel adViewModel)
        {
            var ad = new Ad
            {
                Name = adViewModel.Name,
                Description = adViewModel.Description,
                Price = adViewModel.Price,
                OwnerId = GetUserId(),
                ImageUrl = adViewModel.ImageUrl,
                CreatedOn = DateTime.Now,
                CategoryId = adViewModel.CategoryId
            };


            await dbContext.Ads.AddAsync(ad);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        public async Task<IActionResult> Cart()
        {
            var myAds = await dbContext.AdBuyers.Where(ad => ad.BuyerId == GetUserId()).Select(ad => new AdAllViewModel
            {
                Id = ad.Ad.Id,
                Category = ad.Ad.Category.Name,
                Description = ad.Ad.Description,
                ImageUrl = ad.Ad.ImageUrl,
                Name = ad.Ad.Name,
                Price = ad.Ad.Price
            }).ToListAsync();
            return View(myAds);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await dbContext.Ads.FindAsync(id);

            if (ad == null)
            {
                return NotFound();
            }

            var adViewModel = new AdFormViewModel
            {
                Id = ad.Id,
                Name = ad.Name,
                Price = ad.Price,
                ImageUrl = ad.ImageUrl,
                Description = ad.Description,
                CategoryId = ad.CategoryId,
                Categories = await dbContext.Categories.Select(cat => new CategoryViewModel
                {
                    Id = cat.Id,
                    Name = cat.Name
                }).ToListAsync()
            };

            return View(adViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ad = await dbContext.Ads.FindAsync(model.Id);

            if (ad == null)
            {
                return NotFound();
            }

            ad.Name = model.Name;
            ad.Price = model.Price;
            ad.ImageUrl = model.ImageUrl;
            ad.Description = model.Description;
            ad.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
            return RedirectToAction("All", "Ad");
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var usedId = GetUserId();

            var alreadyAdded = await dbContext.AdBuyers.FirstOrDefaultAsync(ab => ab.BuyerId == usedId && ab.AdId == id);

            if (alreadyAdded == null)
            {
                var adBuyer = new AdBuyer
                {
                    BuyerId = usedId,
                    AdId = id,
                };

                await dbContext.AdBuyers.AddAsync(adBuyer);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Cart", "Ad");
            }

            return RedirectToAction("All", "Ad");
        }

        [HttpH]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var adNeeded = await dbContext.Ads.FindAsync(id);

            if (adNeeded == null)
            {
                return BadRequest();
            }

            var neededAdBuyer = await dbContext.AdBuyers.FirstOrDefaultAsync(ab => ab.BuyerId == GetUserId() && ab.AdId == id);

            if (neededAdBuyer == null)
            {
                return BadRequest();
            }

            dbContext.AdBuyers.Remove(neededAdBuyer);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("All", "Ad");
        }

        public string GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return userId;
        }

    }
}










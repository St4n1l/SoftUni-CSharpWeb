using Homies.Data;
using Homies.Data.Entities;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Xml.Linq;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        public readonly HomiesDbContext dbContext;

        public EventController(HomiesDbContext dbContext)
        {

            this.dbContext = dbContext;
        }

        public async Task<IActionResult> All()
        {

            var allEvents = await dbContext.Events.Select(e => new EventAllViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start.ToString("dd/MM/yyyy H:mm"),
                Type = e.Type.Name,
                Organiser = e.Organiser.UserName
            }).ToListAsync();

            return View(allEvents);
        }

        public async Task<IActionResult> Joined(string userId)
        {
            var currentUser = await dbContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (currentUser == null)
            {
                return RedirectToAction("Index", "Home");
            }


            var allJoinedEventsId = await dbContext.EventsParticipants.Where(ep => ep.HelperId == userId).Select(ep => ep.EventId).ToListAsync();

            var allEvents = await dbContext.Events.Where(e => allJoinedEventsId.Contains(e.Id)).Select(e => new EventAllViewModel
            {
                Name = e.Name,
                Type = e.Type.Name,
                Start = e.Start.ToString("dd/MM/yyyy H:mm"),
                Organiser = e.Organiser.UserName
            }).ToListAsync();

            return View(allEvents);
        }

        public async Task<IActionResult> Add()
        {
            var types = await dbContext.Types.Select(t => new TypeViewModel { Id = t.Id, Name = t.Name }).ToListAsync();

            var newEvent = new EventFormViewModel
            {
                Types = types,
            };

            return View(newEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel eventModel)
        {
            if (!GetTypes().Any(e => e.Id == eventModel.TypeId))
            {
                ModelState.AddModelError(nameof(eventModel.TypeId), "Type does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }

            string currentUserId = GetUserId();

            var eventToAdd = new Event()
            {
                Name = eventModel.Name,
                Description = eventModel.Description,
                CreatedOn = DateTime.Now,
                TypeId = eventModel.TypeId,
                OrganiserId = currentUserId,
                Start = eventModel.Start,
                End = eventModel.End
            };

            await dbContext.Events.AddAsync(eventToAdd);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Event");


            //if (ModelState.IsValid)
            //{
            //    var newEvent = new Event
            //    {
            //        Name = viewModel.Name,
            //        Description = viewModel.Description,
            //        Start = viewModel.Start,
            //        End = viewModel.End,
            //        TypeId = viewModel.TypeId,
            //        CreatedOn = DateTime.UtcNow,
            //        OrganiserId = GetUserId()
            //    };

            //    await dbContext.AddAsync(newEvent);
            //    await dbContext.SaveChangesAsync();
            //}

            //viewModel.Types = dbContext.Types
            //    .Select(t => new EventAddTypeViewModel
            //    {
            //        Id = t.Id,
            //        Name = t.Name
            //    })
            //    .ToList();

            //return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int eventId)
        {
            var eventToEdit = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId);

            if (eventToEdit == null)
            {
                return BadRequest();
            }

            if (eventToEdit.OrganiserId.ToString() != GetUserId())
            {
                return Unauthorized();
            }

            var currentEvent = new EventFormViewModel()
            {
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                Start = eventToEdit.Start,
                End = eventToEdit.End,
                Types = GetTypes()
            };

            return View(currentEvent);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormViewModel model)
        {
            var eventToEdit = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (eventToEdit == null)
            {
                return BadRequest();
            }

            if (eventToEdit.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            eventToEdit.Name = model.Name;
            eventToEdit.Description = model.Description;
            eventToEdit.Start = model.Start;
            eventToEdit.End = model.End;
            eventToEdit.TypeId = model.TypeId;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Join(int id)
        {
            var eventToJoin = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (eventToJoin == null)
            {
                return BadRequest();
            }

            await dbContext.EventsParticipants.AddAsync(new EventParticipant
            {
                EventId = eventToJoin.Id,
                HelperId = GetUserId()
            });

            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Leave(int id)
        {
            var eventToLeave = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (eventToLeave == null)
            {
                return BadRequest();
            }

            if (eventToLeave.OrganiserId.ToString() == GetUserId())
            {
                return BadRequest();
            }

            var entityRemoval = await dbContext.EventsParticipants.FirstOrDefaultAsync(ep => ep.EventId == id && ep.HelperId == GetUserId());
            dbContext.EventsParticipants.Remove(entityRemoval);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Event");
        }

        private IEnumerable<TypeViewModel> GetTypes()
           => dbContext
               .Types
               .Select(t => new TypeViewModel()
               {
                   Id = t.Id,
                   Name = t.Name
               });

        private string GetUserId()
           => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

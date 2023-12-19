using Homies.Data;
using Homies.Data.Entities;
using Homies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homies.Controllers
{
    public class EventController : HomeController
    {
        private readonly HomiesDbContext dbContext;

        public EventController(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> All()
        {
            var allEvents = await dbContext.Events.Select(e => new AllEventViewModel
            {
                Name = e.Name,
                Id = e.Id,
                Type = e.Type.Name,
                Start = e.Start,
                Organiser = e.Organiser.UserName,
            }).ToListAsync();

            return View(allEvents);
        }

        [HttpPost]
        public IActionResult Join(int id)
        {
            var currentEvent = dbContext.Events.Find(id);

            if (currentEvent == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            var entry = new EventParticipant()
            {
                EventId = currentEvent.Id,
                HelperId = currentUserId
            };

            if (dbContext.EventParticipants.Contains(entry))
            {
                return RedirectToAction("All", "Event");
            }

            dbContext.EventParticipants.Add(entry);
            dbContext.SaveChanges();
            return RedirectToAction("All", "Event");
        }

        [HttpPost]
        public IActionResult Leave(int id)
        {

            var currentUser = GetUserId();
            var currentEvent = dbContext.Events.Find(id);

            if (currentEvent == null)
            {
                return BadRequest();
            }

            var entry = dbContext.EventParticipants.FirstOrDefault(ep => ep.HelperId == currentUser && ep.EventId == id);
            dbContext.EventParticipants.Remove(entry);
            dbContext.SaveChanges();

            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Details(int id)
        {

            var eventToFind = await dbContext.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            var type = await dbContext.Types.FirstOrDefaultAsync(t => t.Id == eventToFind.TypeId);

            var model = new AllEventViewModel()
            {
                Id = eventToFind.Id,
                Name = eventToFind.Name,
                Description = eventToFind.Description,
                OrganiserId = eventToFind.OrganiserId,
                Organiser = eventToFind.Organiser.UserName,
                CreatedOn = eventToFind.CreatedOn,
                Start = eventToFind.Start,
                End = eventToFind.End,
                Type = type.Name,
            };

            return View(model);

        }


        public async Task<IActionResult> Joined()
        {
            string currentUserId = GetUserId();
            var currentUser = dbContext.Users.Find(currentUserId);

            var allEvents = new AllEventsQueryModel()
            {
                Events = dbContext.EventParticipants
                    .Where(ep => ep.HelperId == currentUserId)
                    .Select(ep => new AllEventViewModel()
                    {
                        Id = ep.EventId,
                        Name = ep.Event.Name,
                        Type = ep.Event.Type.Name,
                        Start = ep.Event.Start,
                    })
            };

            return View(allEvents);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await GetAddViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel newEvent)
        {
            var model = await AddEventModel(newEvent);

            return RedirectToAction("All","Event");
        }

        private async Task<IActionResult> AddEventModel(AddEventViewModel newEvent)
        {

            if (!ModelState.IsValid && newEvent.Start > newEvent.End)
            {
                return BadRequest();
            }

            var currentEvent = new Event()
            {
                OrganiserId = GetUserId(),
                Description = newEvent.Description,
                End = newEvent.End,
                Name = newEvent.Name,
                Start = newEvent.Start,
                TypeId = newEvent.TypeId,
            };

            await dbContext.Events.AddAsync(currentEvent);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Event");
        }

        private async Task<AddEventViewModel> GetAddViewModel()
        {
            var typeList = await dbContext.Types.ToListAsync();

            var types = new List<TypeViewModel>();

            foreach (var type in typeList)
            {
                var currentType = new TypeViewModel()
                {
                    Id = type.Id,
                    Name = type.Name,
                };

                types.Add(currentType);
            }

            var model = new AddEventViewModel
            {
                Types = types
            };

            return model;
        }
    }
}

using Homies.Data;
using Homies.Data.Entities;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : HomeController
    {
        private readonly HomiesDbContext dbContext;

        public EventController(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> All()
        {
            var model = await GetAllEvents();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await GetAddViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            var newEvent = await AddNewEvent(model);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Joined()
        {
            var model = await GetMyEventsAsync();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task Join(int eventId)
        {
            var alreadyJoined =
                await dbContext.EventParticipants.FirstOrDefaultAsync(ep => ep.HelperId == GetUserId() && ep.EventId == eventId);

            if (alreadyJoined == null)
            {
                var entry = new EventParticipant()
                {
                    EventId = eventId,
                    HelperId = GetUserId()
                };

                await dbContext.EventParticipants.AddAsync(entry);
                await dbContext.SaveChangesAsync();
            }

        }


        public IActionResult Details(int eventId)
        {
            var model = GetDetailedEvent(eventId);

            return View(model);
        }

        private DetailEventViewModel GetDetailedEvent(int eventId)
        {
            var neededEvent = dbContext.Events.FirstOrDefault(e => e.Id == eventId);

            var currentEvent = new DetailEventViewModel()
            {
                Start = neededEvent.Start,
                Id = eventId,
                Name = neededEvent.Name,
                CreatedOn = neededEvent.CreatedOn,
                Description = neededEvent.Description,
                End = neededEvent.End,
                Organiser = neededEvent.Organiser,
                Type = neededEvent.Type.Name,
            };


            return currentEvent;
        }


        private async Task<IEnumerable<JoinedViewModel>> GetMyEventsAsync()
        {
            var userEvents = await dbContext.EventParticipants.Where(ep => ep.HelperId == GetUserId()).ToListAsync();

            var models = new List<JoinedViewModel>();

            foreach (EventParticipant userEvent in userEvents)
            {
                var model = new JoinedViewModel
                {
                    Id = userEvent.EventId,
                    Name = userEvent.Event.Name,
                    Type = userEvent.Event.Type.Name,
                    OrganiserId = userEvent.HelperId,
                    Organiser = userEvent.Helper.UserName,
                    Start = userEvent.Event.Start,
                };

                models.Add(model);
            }

            return models;
        }

        private async Task<IActionResult> AddNewEvent(AddEventViewModel model)
        {
            if (!ModelState.IsValid && model.Start > model.End)
            {
                return View(model);
            }

            var newEvent = new Event()
            {
                OrganiserId = GetUserId(),
                CreatedOn = DateTime.Now,
                Description = model.Description,
                End = model.End,
                Id = model.Id,
                Name = model.Name,
                Start = model.Start,
                TypeId = model.TypeId
            };

            await dbContext.Events.AddAsync(newEvent);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Event");

        }

        private async Task<AddEventViewModel> GetAddViewModel()
        {
            var types = await dbContext.Types.Select(t => new TypeViewModel()
            {
                Id = t.Id,
                Name = t.Name,
            }).ToListAsync();

            var eventModel = new AddEventViewModel()
            {
                Types = types
            };

            return eventModel;
        }

        private async Task<IEnumerable<AllEventsViewModel>> GetAllEvents()
        {
            var events = await dbContext.Events.Select(e => new AllEventsViewModel()
            {
                Name = e.Name,
                CreatedOn = e.CreatedOn,
                Description = e.Description,
                EndTime = e.End,
                Organiser = e.Organiser,
                Start = e.Start,
                Type = e.Type.Name,

            }).ToListAsync();

            return events;
        }
    }
}

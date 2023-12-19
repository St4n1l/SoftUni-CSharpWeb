using Contacts.Data.Entities;

namespace Contacts.Data.Models
{
    public class AllContactsViewModel
    {
        public IEnumerable<ContactsViewModel> Contacts { get; set; } = new List<ContactsViewModel>();
      
    }
}
//< td > @contact.FirstName </ td >
//    < td > @contact.LastName </ td >
//    < td > @contact.Email </ td >
//    < td > @contact.PhoneNumber </ td >
//    < td > @contact.Address </ td >
////    < td > @contact.Website </ td >
//contact.ContactId
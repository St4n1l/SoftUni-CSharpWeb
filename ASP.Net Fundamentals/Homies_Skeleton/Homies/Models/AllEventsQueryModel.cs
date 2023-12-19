namespace Homies.Models
{
    public class AllEventsQueryModel
    {
        public IEnumerable<AllEventViewModel> Events { get; set; }
            = new List<AllEventViewModel>();
    }
}

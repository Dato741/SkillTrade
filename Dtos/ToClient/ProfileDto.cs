using SkillTrade.Entities;

namespace SkillTrade.Dtos.ToClient
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<ServiceListing> ServiceList { get; set; } = new List<ServiceListing>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

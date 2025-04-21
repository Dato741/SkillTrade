namespace SkillTrade.Dtos.ToClient
{
    public class ServiceListingDto
    {
        public int ServiceId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PayOffered { get; set; }
        public string ServicePostedBy { get; set; } = string.Empty;
    }
}

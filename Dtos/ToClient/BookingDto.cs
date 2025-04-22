namespace SkillTrade.Dtos.ToClient
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string ServiceDescription { get; set; } = string.Empty;
        public int PayOffered { get; set; }
    }
}

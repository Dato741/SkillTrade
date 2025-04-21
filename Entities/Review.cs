using System.Text.Json.Serialization;

namespace SkillTrade.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int? ProfileId { get; set; }

        [JsonIgnore]
        public Profile? Profile { get; set; }
        public int? BookingId { get; set; }

        [JsonIgnore]
        public Booking? Booking { get; set; }
    }
}

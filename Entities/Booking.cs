using System.Text.Json.Serialization;

namespace SkillTrade.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int? ProfileId { get; set; }

        [JsonIgnore]
        public Profile? Profile { get; set; }
        public int? ServiceId { get; set; }

        [JsonIgnore]
        public ServiceListing? Service { get; set; }
        public int? ReviewId { get; set; }

        [JsonIgnore]
        public Review? Review { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace SkillTrade.Entities
{
    public class ServiceListing
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PayOffered { get; set; }
        public string ServicePostedBy { get; set; } = string.Empty;
        public int? ProfileId { get; set; }

        [JsonIgnore]
        public Profile? Profile { get; set; }
        public int? CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }

        [JsonIgnore]
        public List<Review>? Reviews { get; set; }
    }
}

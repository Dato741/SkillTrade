using System.Text.Json.Serialization;

namespace SkillTrade.Entities
{
    public class ServiceListing
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        public int? CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }

    }
}

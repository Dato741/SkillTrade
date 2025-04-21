namespace SkillTrade.Dtos.Create
{
    public class CreateServiceListingDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PayOffered { get; set; }
        public int CategoryId { get; set; }
    }
}

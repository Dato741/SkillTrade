namespace SkillTrade.Dtos.Update
{
    public class UpdateServiceListingDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PayOffered { get; set; }
        public int CategoryId { get; set; }
    }
}

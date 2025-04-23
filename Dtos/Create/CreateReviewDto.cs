namespace SkillTrade.Dtos.Create
{
    public class CreateReviewDto
    {
        public string Comment { get; set; } = string.Empty;
        public int ServiceId { get; set; }
    }
}

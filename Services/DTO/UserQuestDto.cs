namespace Services.DTO;

public class UserQuestDto
{
    public int QuestTitle { get; set; }
    public string? Comments { get; set; }
    public string? ImageUrl { get; set; }
    public string ProofOfCompletion { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string QuestPoints { get; set; } = default!;
}

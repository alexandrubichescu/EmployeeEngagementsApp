namespace Services.DTO;

public class AddUserQuestDto
{
    public int QuestId { get; set; }
    public string? Comments { get; set; }
    public string? ImageUrl { get; set; }
    public string ProofOfCompletion { get; set; } = default!;
}

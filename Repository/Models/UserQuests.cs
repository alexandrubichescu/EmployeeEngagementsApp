namespace Repository.Models;

public class UserQuest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuestId { get; set; }
    public string? Comments { get; set; } 
    public string? ImageUrl { get; set; }
    public string ProofOfCompletion { get; set; } = default!;

}

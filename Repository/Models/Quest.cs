namespace Repository.Models;

public class Quest
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Points { get; set; }
    public int CreatorId { get; set; }
    public QuestStatus Status { get; set; }
    public int ApprovedBy { get; set; }
}

namespace Services.DTO;

public class UpdateQuestDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Points { get; set; }
}

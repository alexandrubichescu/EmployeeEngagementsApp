namespace Services.DTO;

public class AddQuestDTO
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Points { get; set; }
}

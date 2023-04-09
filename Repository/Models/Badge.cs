
namespace Repository.Models;

public class Badge
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public int TokenReward { get; set; }

    public List<User> Users { get; set; }
}

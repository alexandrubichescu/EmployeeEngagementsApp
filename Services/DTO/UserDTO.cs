namespace Services.DTO;

public class UserDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Role { get; set; } = default!;

    /// <summary>
    /// User points
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// User Won Quests
    /// </summary>
    //public List<Quest> Quests { get; set; }
}

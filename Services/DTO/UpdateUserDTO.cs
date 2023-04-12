using Repository.Models;

namespace Services.DTO;

public class UpdateUserDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Role Role { get; set; } = default!;
    public string Password { get; set; } = default!;
    public int Points { get; set; }
}

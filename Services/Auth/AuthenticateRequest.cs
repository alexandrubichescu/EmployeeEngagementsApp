using System.ComponentModel.DataAnnotations;

namespace Services.Auth;

public class AuthenticateRequest
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}

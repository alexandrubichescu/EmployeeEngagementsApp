﻿

using Repository.Models;

namespace Services.Interfaces;

public interface IJwtUtils
{
    public string GenerateJwtToken(User user);
    public int? ValidateJwtToken(string token);
}

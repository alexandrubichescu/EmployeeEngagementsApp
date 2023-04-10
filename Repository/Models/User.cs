﻿using System.Text.Json.Serialization;

namespace Repository.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Role { get; set; } = default!;

    [JsonIgnore]
    public string Password { get; set; } = default!;


    /// <summary>
    /// User points
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// User Won badges
    /// </summary>
    public List<Badge>? Badges { get; set; }

    /// <summary>
    /// User complete quests
    /// </summary>
    //public List<Quest>? Quests { get; set; }
}

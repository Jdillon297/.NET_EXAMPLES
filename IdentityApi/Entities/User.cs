﻿using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = string.Empty;

    public Cart Cart { get; set; }

    
}

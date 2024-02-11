namespace IdentityApi.Entities;

using System;
using Microsoft.AspNetCore.Identity;

public class Role: IdentityRole<int>
{
    public string Description { get; set; }
}

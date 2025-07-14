﻿using Microsoft.AspNetCore.Identity;

namespace WebAppDbFirstApproach.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}

using System;
using Microsoft.AspNetCore.Identity;

namespace MVC_CRUD.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}

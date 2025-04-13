using Microsoft.AspNetCore.Identity;

namespace EFlowers_Auth.Implementation;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;
}

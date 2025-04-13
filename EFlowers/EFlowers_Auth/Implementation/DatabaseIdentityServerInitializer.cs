using IdentityModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace EFlowers_Auth.Implementation;

public class DatabaseIdentityServerInitializer :IDatabaseSeedInitializer
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly RoleManager<IdentityRole> _roleManager;

    public DatabaseIdentityServerInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void InitializeSeedRoles()
    {
        if (!_roleManager.RoleExistsAsync(IdentityConfiguration.Admin).Result)
        {
            IdentityRole roleAdmin = new IdentityRole();
            roleAdmin.Name = IdentityConfiguration.Admin;
            roleAdmin.NormalizedName = IdentityConfiguration.Admin.ToUpper();
            _roleManager.CreateAsync(roleAdmin).Wait();
        }

        if (!_roleManager.RoleExistsAsync(IdentityConfiguration.Client).Result)
        {
            IdentityRole roleClient = new IdentityRole();
            roleClient.Name = IdentityConfiguration.Client;
            roleClient.NormalizedName = IdentityConfiguration.Client.ToUpper();
            _roleManager.CreateAsync(roleClient).Wait();
        }
    }

    public void InitializeSeedUsers()
    {
        if (_userManager.FindByEmailAsync("admin@ltestore.com").Result == null)
        {
            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@ltestore.com",
                NormalizedEmail = "ADMIN@LTESTORE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "+55 (00) 90000-0000",
                FirstName = "Usuario",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            IdentityResult resultAdmin = _userManager.CreateAsync(admin, "Teste@2025").Result;
            if (resultAdmin.Succeeded)
            {
                _userManager.AddToRoleAsync(admin, IdentityConfiguration.Admin).Wait();
                var adminClaims = _userManager.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                    new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
                }).Result;
            }
        }

        if (_userManager.FindByEmailAsync("client@ltestore.com").Result == null)
        {
            ApplicationUser client = new ApplicationUser()
            {
                UserName = "client",
                NormalizedUserName = "CLIENT",
                Email = "client@ltestore.com",
                NormalizedEmail = "CLIENT@LTESTORE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "+55 (00) 90000-0000",
                FirstName = "Usuario",
                LastName = "Client",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            IdentityResult resultClient = _userManager.CreateAsync(client, "Teste@2025").Result;
            if (resultClient.Succeeded)
            {
                _userManager.AddToRoleAsync(client, IdentityConfiguration.Client).Wait();

                var clientClaims = _userManager.AddClaimsAsync(client, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                    new Claim(JwtClaimTypes.GivenName, client.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, client.LastName),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
                }).Result;
            }
        }
    }
}

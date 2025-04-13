using IdentityModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace EFlowers_Auth.Implementation;

public class DatabaseIdentityServerInitializer :IDatabaseSeedInitializer
{
    private readonly UserManager<AppUser> _userManager;

    private readonly RoleManager<IdentityRole> _roleManager;

    public DatabaseIdentityServerInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void InitializeSeedRoles()
    {
        if (!_roleManager.RoleExistsAsync(IdentityConfiguration.Admin).Result)
        {
            //cria o perfil Admin
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
            AppUser admin = new AppUser()
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

            IdentityResult resultAdmin = _userManager.CreateAsync(admin, "123456789").Result;
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
            AppUser client = new AppUser()
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

            IdentityResult resultClient = _userManager.CreateAsync(client, "123456789").Result;
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



















    public void InitializeSeedDatabase()
    {
        if (_roleManager.FindByNameAsync(IdentityConfiguration.Admin).Result == null)
        {
            IdentityRole roleAdmin = new IdentityRole();
            roleAdmin.Name = IdentityConfiguration.Admin;
            roleAdmin.NormalizedName = IdentityConfiguration.Admin.ToUpper();
            _roleManager.CreateAsync(roleAdmin).Wait();

            AppUser admin = new AppUser()
            {
                UserName = "Admin",
                NormalizedUserName = "MACORATTI-ADMIN",
                Email = "macoratti_admin@com.br",
                NormalizedEmail = "MACORATTI_ADMIN@COM.BR",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "+55 (11) 12345-6789",
                FirstName = "Macoratti",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //cria o usuário Admin e atribui a senha
            IdentityResult resultAdmin = _userManager.CreateAsync(admin, "Numsey#2022").Result;
            if (resultAdmin.Succeeded)
            {
                //inclui o usuário admin ao perfil admin
                _userManager.AddToRoleAsync(admin, IdentityConfiguration.Admin).Wait();

                //inclui as claims do usuário admin
                var adminClaims = _userManager.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                    new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
                }).Result;
            }
        }

        // se o perfil Client não existir então cria o perfil, cria o usuario e atribui ao perfil
        if (_roleManager.FindByNameAsync(IdentityConfiguration.Client).Result == null)
        {
            //cria o perfil Client
            IdentityRole roleClient = new IdentityRole();
            roleClient.Name = IdentityConfiguration.Client;
            roleClient.NormalizedName = IdentityConfiguration.Client.ToUpper();
            _roleManager.CreateAsync(roleClient).Wait();

            //define os dados do usuário client
            AppUser client = new AppUser()
            {
                UserName = "macoratti-client",
                NormalizedUserName = "MACORATTI-CLIENT",
                Email = "macoratti_client@com.br",
                NormalizedEmail = "MACORATTI_CLIENT@COM.BR",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "+55 (11) 12345-6789",
                FirstName = "Macoratti",
                LastName = "Client",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //cria o usuário Client e atribui a senha
            IdentityResult resultClient = _userManager.CreateAsync(client, "Numsey#2022").Result;
            //inclui o usuário Client ao perfil Client
            if (resultClient.Succeeded)
            {
                _userManager.AddToRoleAsync(client, IdentityConfiguration.Client).Wait();

                //adiciona as claims do usuário Client
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

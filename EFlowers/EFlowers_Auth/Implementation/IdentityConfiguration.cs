using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace EFlowers_Auth.Implementation;

public class IdentityConfiguration
{
    public const string Admin = "admin";
    public const string Client = "client";

    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new ApiScope("EFlowers", "Eflowers Server"),
        new ApiScope(name: "read", "Read data."),
        new ApiScope(name: "write", "Write data."),
        new ApiScope(name: "delete", "Delete data."),
    };

    public static IEnumerable<Client> Clients => new List<Client>
    {
        new Client
        {
            ClientId = "client",
            ClientSecrets = { new Secret("teste".Sha256())},
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes = {"read", "write", "profile" }
        },
        new Client
        {
            ClientId = "EFlowers",
            ClientSecrets = { new Secret("teste".Sha256())},
            AllowedGrantTypes = GrantTypes.Code,
            RedirectUris = {"https://localhost:7165/signin-oidc"},
            PostLogoutRedirectUris = {"https://localhost:7165/signout-callback-oidc"},
            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                "EFlowers"
            }
        }
    };
}

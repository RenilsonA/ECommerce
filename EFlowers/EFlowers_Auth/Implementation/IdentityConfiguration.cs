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
        new ApiScope("LTEStore", "LTEStore Server"),
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
            ClientId = "LTEStore",
            ClientSecrets = { new Secret("teste".Sha256())},
            AllowedGrantTypes = GrantTypes.Code,
            RedirectUris = {"https://localhost:7101/signin-oidc"},
            PostLogoutRedirectUris = {"https://localhost:7101/signout-callback-oidc"},
            AllowedCorsOrigins = { "https://localhost:7101" },
            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                "LTEStore"
            },
            AllowOfflineAccess = true
        }
    };
}

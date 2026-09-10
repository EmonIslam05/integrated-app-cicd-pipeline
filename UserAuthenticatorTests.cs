using LoginModule;
using Xunit;

namespace IntegratedApp.Tests;

public class UserAuthenticatorTests
{
    private readonly IUserAuthenticator _authenticator = new UserAuthenticator();

    [Fact]
    public void Authenticate_ValidCredentials_ReturnsSuccess()
    {
        var result = _authenticator.Authenticate("admin", "Admin123!");

        Assert.True(result.Success);
        Assert.Equal("Administrator", result.Role);
    }

    [Fact]
    public void Authenticate_InvalidPassword_ReturnsFailure()
    {
        var result = _authenticator.Authenticate("admin", "wrong-password");

        Assert.False(result.Success);
        Assert.Equal("Invalid username or password.", result.Message);
    }

    [Theory]
    [InlineData("", "Admin123!")]
    [InlineData("admin", "")]
    [InlineData(null, null)]
    public void Authenticate_MissingCredentials_ReturnsFailure(string? username, string? password)
    {
        var result = _authenticator.Authenticate(username!, password!);

        Assert.False(result.Success);
    }
}

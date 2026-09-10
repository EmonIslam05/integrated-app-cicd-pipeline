namespace LoginModule;

/// <summary>
/// Simple in-memory authenticator used to demonstrate module integration.
/// In a production system this would call out to a membership provider,
/// identity server, or database, but the public contract (IUserAuthenticator)
/// would stay the same, which is the point of the exercise: swap the
/// implementation without touching the modules that depend on it.
/// </summary>
public class UserAuthenticator : IUserAuthenticator
{
    private readonly Dictionary<string, (string Password, string Role)> _users = new(StringComparer.OrdinalIgnoreCase)
    {
        ["admin"] = ("Admin123!", "Administrator"),
        ["analyst"] = ("Analyst123!", "Analyst"),
    };

    public AuthenticationResult Authenticate(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return new AuthenticationResult(false, username ?? string.Empty, string.Empty, "Username and password are required.");
        }

        if (_users.TryGetValue(username, out var record) && record.Password == password)
        {
            return new AuthenticationResult(true, username, record.Role, "Login successful.");
        }

        return new AuthenticationResult(false, username, string.Empty, "Invalid username or password.");
    }
}

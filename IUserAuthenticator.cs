namespace LoginModule;

/// <summary>
/// Contract for any authentication provider used by the integrated application.
/// Keeping this as an interface allows the console host (or any future host,
/// e.g. a web API) to depend on an abstraction rather than a concrete class.
/// </summary>
public interface IUserAuthenticator
{
    AuthenticationResult Authenticate(string username, string password);
}

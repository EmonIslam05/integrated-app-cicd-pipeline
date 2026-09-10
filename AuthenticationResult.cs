namespace LoginModule;

/// <summary>
/// Immutable result returned by the authentication module.
/// Downstream modules (data processing / reporting) only ever see this
/// simple record, never the internal user store.
/// </summary>
public sealed record AuthenticationResult(bool Success, string UserName, string Role, string Message);

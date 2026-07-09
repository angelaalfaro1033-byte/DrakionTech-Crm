using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using DrakionTech.Crm.Data.Services;

public class GoogleAuthService
{
    private readonly ICurrentUserContext _currentUserContext;
    private readonly Dictionary<string, UserCredential> _credentials = new();

    public GoogleAuthService(ICurrentUserContext currentUserContext)
    {
        _currentUserContext = currentUserContext;
    }

    public async Task<UserCredential> GetCredentialAsync(int? usuarioId = null)
    {
        var scopes = new[] { CalendarService.Scope.Calendar };

        var userId = (usuarioId ?? _currentUserContext.UserId)?.ToString()
            ?? Environment.UserName;

        if (_credentials.TryGetValue(userId, out var cachedCredential))
            return cachedCredential;

        var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.FromFile("credentials.json").Secrets,
            scopes,
            "calendar_" + userId,
            CancellationToken.None,
            new FileDataStore("tokens-calendar", true)
        );

        _credentials[userId] = credential;
        return credential;
    }
}

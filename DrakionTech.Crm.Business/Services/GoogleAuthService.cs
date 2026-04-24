using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;

public class GoogleAuthService
{
    private UserCredential? _credential;

    public async Task<UserCredential> GetCredentialAsync()
    {
        if (_credential != null)
            return _credential;

        var scopes = new[]
        {
            CalendarService.Scope.Calendar,
            DriveService.Scope.DriveFile
        };

        var userId = Environment.UserName;

        _credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.FromFile("credentials.json").Secrets,
            scopes,
            "user_" + userId,
            CancellationToken.None,
            new FileDataStore("tokens", true)
        );

        return _credential;
    }
}
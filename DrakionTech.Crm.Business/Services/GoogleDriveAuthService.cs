using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;

public class GoogleDriveAuthService
{
    private UserCredential? _credential;

    public async Task<UserCredential> GetCredentialAsync()
    {
        if (_credential != null)
            return _credential;

        _credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.FromFile("credentials.json").Secrets,
            new[] { DriveService.Scope.DriveFile },
            "company_drive",
            CancellationToken.None,
            new FileDataStore("tokens-drive", true)
        );

        return _credential;
    }
}

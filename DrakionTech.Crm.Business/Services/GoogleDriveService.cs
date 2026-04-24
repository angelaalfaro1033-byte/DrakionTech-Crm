using Google.Apis.Drive.v3;
using Google.Apis.Services;

public class GoogleDriveService
{
    private readonly GoogleAuthService _authService;
    private DriveService _driveService;

    public GoogleDriveService(GoogleAuthService authService)
    {
        _authService = authService;
    }

    private async Task InitAsync()
    {
        if (_driveService != null) return;

        var credential = await _authService.GetCredentialAsync();

        _driveService = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "CRM Google Drive Integration",
        });
    }

    public async Task<(byte[] bytes, string extension, string contentType)> DescargarArchivoAsync(string fileId, string url)
    {
        await InitAsync();

        try
        {
            var file = await _driveService.Files.Get(fileId).ExecuteAsync();

            using var stream = new MemoryStream();

            if (file.MimeType.StartsWith("application/vnd.google-apps"))
            {
                string exportMime;
                string extension;

                switch (file.MimeType)
                {
                    case "application/vnd.google-apps.document":
                        exportMime = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        extension = ".docx";
                        break;

                    case "application/vnd.google-apps.spreadsheet":
                        exportMime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        extension = ".xlsx";
                        break;

                    case "application/vnd.google-apps.presentation":
                        exportMime = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                        extension = ".pptx";
                        break;

                    default:
                        exportMime = "application/pdf";
                        extension = ".pdf";
                        break;
                }

                var request = _driveService.Files.Export(fileId, exportMime);
                await request.DownloadAsync(stream);
                stream.Position = 0;

                return (stream.ToArray(), extension, exportMime);
            }
            else
            {
                var request = _driveService.Files.Get(fileId);
                await request.DownloadAsync(stream);

                var ext = string.IsNullOrEmpty(Path.GetExtension(file.Name))
                    ? ".bin"
                    : Path.GetExtension(file.Name);

                return (stream.ToArray(), ext, file.MimeType);
            }
        }
        catch
        {
            using var http = new HttpClient();
            var bytes = await http.GetByteArrayAsync(url);

            return (bytes, Path.GetExtension(url), "application/octet-stream");
        }
    }

    public async Task<string> ObtenerNombreAsync(string fileId, string extension)
    {
        await InitAsync();

        var file = await _driveService.Files.Get(fileId).ExecuteAsync();
        return file.Name + extension;
    }

    public async Task<(string fileId, string webViewLink)> SubirArchivoAsync(
    string nombre,
    string mimeType,
    Stream contenido)
    {
        await InitAsync();

        var fileMetadata = new Google.Apis.Drive.v3.Data.File
        {
            Name = nombre
        };

        var request = _driveService.Files.Create(fileMetadata, contenido, mimeType);
        request.Fields = "id, webViewLink";

        var uploadResult = await request.UploadAsync();

        if (uploadResult.Status != Google.Apis.Upload.UploadStatus.Completed)
        {
            throw new Exception($"Error subiendo archivo a Drive: {uploadResult.Exception?.Message}");
        }

        var file = request.ResponseBody;

        if (file == null)
            throw new Exception("Drive no devolvió información del archivo (ResponseBody null)");

        return (file.Id, file.WebViewLink);
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;
using Microsoft.Extensions.Configuration;

// Install-Package FluentFTP
// Install-Package Microsoft.Extensions.Configuration

public class FtpHelper
{
    private readonly IConfiguration _configuration;

    public FtpHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private string GetFtpSetting(string key)
    {
        return _configuration[$"FtpSettings:{key}"];
    }

    public async Task UploadFileAsync(string localFile, string remoteFile, FtpRemoteExists remoteExists = FtpRemoteExists.Overwrite, bool createDirectory = false, FtpVerify verify = FtpVerify.None, CancellationToken cancellationToken = default)
    {
        try
        {
            using (var ftpClient = new AsyncFtpClient(GetFtpSetting("Host"), GetFtpSetting("Username"), GetFtpSetting("Password")))
            {
                await ftpClient.Connect(cancellationToken);
                ftpClient.Config.RetryAttempts = 3; // Consider making this configurable

                await ftpClient.UploadFile(localFile, remoteFile, remoteExists, createDirectory, verify, cancellationToken);
            }
        }
        catch (FtpException ex)
        {
            // Log specific FTP errors
            throw new Exception($"FTP upload failed: {ex.Message}");
        }
    }

    public async Task DownloadFileAsync(string localFile, string remoteFile, FtpLocalExists localExists = FtpLocalExists.Overwrite, FtpVerify verify = FtpVerify.None, CancellationToken cancellationToken = default)
    {
        try
        {
            using (var ftpClient = new AsyncFtpClient(GetFtpSetting("Host"), GetFtpSetting("Username"), GetFtpSetting("Password")))
            {
                await ftpClient.Connect(cancellationToken);
                ftpClient.Config.RetryAttempts = 3; // Consider making this configurable

                await ftpClient.DownloadFile(localFile, remoteFile, localExists, verify, cancellationToken);
            }
        }
        catch (FtpException ex)
        {
            // Log specific FTP errors
            throw new Exception($"FTP download failed: {ex.Message}");
        }
    }
}

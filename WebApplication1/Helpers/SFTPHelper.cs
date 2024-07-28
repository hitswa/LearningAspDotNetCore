using System;
using System.IO;
using WinSCP;
using Microsoft.Extensions.Configuration;

// Install-Package WinSCP
// Install-Package Microsoft.Extensions.Configuration

namespace WebApplication1.Helpers
{
    public class SftpHelper
    {
        /// <summary>
        /// SFTP host
        /// </summary>
        private readonly string _host;
        /// <summary>
        /// SFTP username
        /// </summary>
        private readonly string _username;
        /// <summary>
        /// SFTP password
        /// </summary>
        private readonly string _password;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public SftpHelper(IConfiguration configuration)
        {
            _host = configuration["FtpSettings:Host"];
            _username = configuration["FtpSettings:Username"];
            _password = configuration["FtpSettings:Password"];
        }

        /// <summary>
        /// Upload File to SFTP Server
        /// </summary>
        /// <param name="localFilePath"></param>
        /// <param name="remoteFilePath"></param>
        /// <returns></returns>
        public bool UploadFile(string localFilePath, string remoteFilePath)
        {
            try
            {
                using (var session = new Session())
                {
                    session.Open(new SessionOptions
                    {
                        Protocol = Protocol.Sftp,
                        HostName = _host,
                        UserName = _username,
                        Password = _password
                    });

                    session.PutFiles(new TransferOptions { TransferMode = TransferMode.Auto }, new[] { new TransferFileInfo(localFilePath, remoteFilePath) });
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Upload File to SFTP Server asynchronously
        /// </summary>
        /// <param name="localFilePath"></param>
        /// <param name="remoteFilePath"></param>
        /// <returns></returns>
        public async Task<bool> UploadFileAsync(string localFilePath, string remoteFilePath)
        {
            try
            {
                using (var session = new Session())
                {
                    await session.OpenAsync(new SessionOptions
                    {
                        Protocol = Protocol.Sftp,
                        HostName = _host,
                        UserName = _username,
                        Password = _password
                    });

                    await session.PutFilesAsync(new TransferOptions { TransferMode = TransferMode.Auto }, new[] { new TransferFileInfo(localFilePath, remoteFilePath) });
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Download File from SFTP Server
        /// </summary>
        /// <param name="remoteFilePath"></param>
        /// <param name="localFilePath"></param>
        /// <returns></returns>
        public bool DownloadFile(string remoteFilePath, string localFilePath)
        {
            try
            {
                using (var session = new Session())
                {
                    session.Open(new SessionOptions
                    {
                        Protocol = Protocol.Sftp,
                        HostName = _host,
                        UserName = _username,
                        Password = _password
                    });

                    session.GetFiles(new TransferOptions { TransferMode = TransferMode.Auto }, new[] { new TransferFileInfo(remoteFilePath, localFilePath) });
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Download File from SFTP Server asynchronously
        /// </summary>
        /// <param name="remoteFilePath"></param>
        /// <param name="localFilePath"></param>
        /// <returns></returns>
        public async Task<bool> DownloadFileAsync(string remoteFilePath, string localFilePath)
        {
            try
            {
                using (var session = new Session())
                {
                    await session.OpenAsync(new SessionOptions
                    {
                        Protocol = Protocol.Sftp,
                        HostName = _host,
                        UserName = _username,
                        Password = _password
                    });

                    await session.GetFilesAsync(new TransferOptions { TransferMode = TransferMode.Auto }, new[] { new TransferFileInfo(remoteFilePath, localFilePath) });
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
                return false;
            }
        }
    }
}

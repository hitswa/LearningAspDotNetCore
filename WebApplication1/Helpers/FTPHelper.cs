using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

// better code 
// https://juldhais.net/how-to-download-files-from-secure-ftp-server-sftp-using-winscp-in-net-895fbb44362c
// https://www.codeproject.com/Tips/5273618/ASP-NET-CORE-Using-SFTP-FTP-in-ASP-NET-CORE-Projec

namespace WebApplication1.Helpers {
    public class FtpHelper {

        [Key]
        private string FtpHost { get; set; }
        [Key]
        private string FtpUsername { get; set; }
        [Key]
        private string FtpPassword  { get; set; }

        public FtpHelper(string ftpHost, string ftpUsername, string ftpPassword)
        {
            FtpHost = ftpHost;
            FtpUsername = ftpUsername;
            FtpPassword = ftpPassword;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        public void UploadFile(string sourceFile, string destinationFile) {
            try
            {
                using (var ftpClient = new FtpClient(FtpHost, FtpUsername, FtpPassword)) {
                    ftpClient.Connect();

                    // upload a file to an existing FTP directory
                    ftpClient.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md");

                    // upload a file and ensure the FTP directory is created on the server
                    ftpClient.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true);

                    // setting upload try for 3 times when fails
                    ftpClient.Config.RetryAttempts = 3;

                    // upload a file and ensure the FTP directory is created on the server, verify the file after upload
                    ftpClient.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, false, FtpVerify.Retry);
                }
            }
            catch (System.Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error uploading file: {ex.Message}");
                throw;
            }
            finally {
                // do nothing
            }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public async Task UploadFileAsync() {
            try
            {
                var token = new CancellationToken();
                using (var ftpClient = new AsyncFtpClient(FtpHost, FtpUsername, FtpPassword)) {
                    await ftpClient.Connect(token);

                    // upload a file to an existing FTP directory
                    await ftpClient.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", token: token);

                    // upload a file and ensure the FTP directory is created on the server
                    await ftpClient.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, token: token);

                    // setting upload try for 3 times when fails
                    ftpClient.Config.RetryAttempts = 3;

                    // upload a file and ensure the FTP directory is created on the server, verify the file after upload
                    await ftpClient.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, FtpVerify.Retry, token: token);

                }
            }
            catch (System.Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error uploading file: {ex.Message}");   
                throw;
            }
            finally {
                // do noting
            }
		}

        /// <summary>
        /// 
        /// </summary>
        public void DownloadFile() {
            try
            {
                using (var ftpClient = new FtpClient(FtpHost, FtpUsername, FtpPassword)) {
                    ftpClient.Connect();

                    // download a file and ensure the local directory is created
                    ftpClient.DownloadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md");

                    // download a file and ensure the local directory is created, verify the file after download
                    ftpClient.DownloadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpLocalExists.Overwrite, FtpVerify.Retry);

                }
            }
            catch (System.Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error uploading file: {ex.Message}"); 
                throw;
            }
            finally {
                // do nothing
            }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public async Task DownloadFileAsync() {
            try
            {
                var token = new CancellationToken();
                using (var ftpClient = new AsyncFtpClient(FtpHost, FtpUsername, FtpPassword)) {
                    await ftpClient.Connect(token);

                    // download a file and ensure the local directory is created
                    await ftpClient.DownloadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", token: token);

                    // download a file and ensure the local directory is created, verify the file after download
                    await ftpClient.DownloadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpLocalExists.Overwrite, FtpVerify.Retry, token: token);

                }    
            }
            catch (System.Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error uploading file: {ex.Message}"); 
                throw;
            }
			finally {
                // do nothing
            }
		}

    }
}
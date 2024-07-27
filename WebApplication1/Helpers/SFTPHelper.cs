// using Renci.SshNet;
// using Renci.SshNet.Async;

// namespace WebApplication1;

// public class SftpHelper
// {
//     public async Task UploadFileAsync(string localFilePath, string remotePath, string host, int port, string username, string password)
//     {
//         using (var client = new SftpClient(host, port, username, password))
//         {
//             try
//             {
//                 await client.ConnectAsync();

//                 // Check if the remote directory exists (optional)
//                 if (!await client.ExistsDirectoryAsync(Path.GetDirectoryName(remotePath)))
//                 {
//                     await client.CreateDirectoryAsync(Path.GetDirectoryName(remotePath));
//                 }

//                 using (var fileStream = File.OpenRead(localFilePath))
//                 {
//                     await client.UploadAsync(fileStream, remotePath);
//                 }
//             }
//             catch (Exception ex)
//             {
//                 // Handle exceptions (e.g., connection issues, file not found)
//                 Console.WriteLine($"Error uploading file: {ex.Message}");
//             }
//         }
//     }
// }

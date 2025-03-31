using Dermastore.Domain.Interfaces;
using Firebase.Storage;
using Microsoft.Extensions.Configuration;

namespace Dermastore.Infrastructure.Services.Firebase
{
    public class FirebaseService : IFirebaseService
    {
        private readonly IConfiguration _config;
        private readonly FirebaseStorage _firebaseStorage;
    
        public FirebaseService(IConfiguration config) 
        {
            _config = config;
            _firebaseStorage = new FirebaseStorage(_config["FirebaseStorage"]);
        }

        public async Task<string> UploadFile(Stream filestream, string fileName, bool isUploadImages)
        {
            var cancellationToken = new CancellationTokenSource();
            var subFolderName = isUploadImages ? "images" : "policy";
            var task = _firebaseStorage
                .Child(subFolderName)
                .Child(fileName)
                .PutAsync(filestream, cancellationToken.Token);
            try
            {
                string downloadUrl = await task;
                return downloadUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
            }
            return string.Empty;
        }

        public async Task<string> GetPolicyUrlAsync(string fileName)
        {
            try
            {
                var cancellationToken = new CancellationTokenSource();
                // Retrieve the download URL for the file stored under "policy/fileName"
                string downloadUrl = await _firebaseStorage
                    .Child("policy")
                    .Child(fileName)
                     .GetDownloadUrlAsync();
                return downloadUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving policy URL: {ex.Message}");
                return string.Empty;
            }
        }
    }
}

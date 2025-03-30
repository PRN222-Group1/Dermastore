using Dermastore.Domain.Interfaces;
using Firebase.Storage;

namespace Dermastore.Infrastructure.Services.Firebase
{
    public class FirebaseService : IFirebaseService
    {
        public FirebaseStorage firebaseStorage = new FirebaseStorage("dermastore-574ab.firebasestorage.app");
        public async Task<string> UploadFile(Stream filestream, string fileName, bool isUploadImages)
        {
            var cancellationToken = new CancellationTokenSource();
            var subFolderName = isUploadImages ? "images" : "policy";
            var task = firebaseStorage
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
                string downloadUrl = await firebaseStorage
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

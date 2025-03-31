namespace Dermastore.Domain.Interfaces
{
    public interface IFirebaseService
    {
        Task<string> UploadFile(Stream filestream, string fileName, bool isUploadImages);
        Task<string> GetPolicyUrlAsync(string fileName);
    }
}

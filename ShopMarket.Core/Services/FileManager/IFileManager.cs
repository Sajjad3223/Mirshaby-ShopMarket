using Microsoft.AspNetCore.Http;

namespace ShopMarket.Core.Services.FileManager
{
    public interface IFileManager
    {
        string SaveFileTo(IFormFile file, string savePath);

        bool DeleteFile(string path,string fileName);
    }
}
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ShopMarket.Core.Services.FileManager
{
    public class FileManager : IFileManager
    {
        public bool DeleteFile(string path , string fileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(),path.Replace("/","\\"), fileName);
                    if(File.Exists(filePath))
                        File.Delete(filePath);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string SaveFileTo(IFormFile file, string savePath)
        {
            if (file == null)
                throw new Exception("File is null");

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string folderLocation = Path.Combine(Directory.GetCurrentDirectory(), savePath.Replace("/", "\\"));

            if (!Directory.Exists(folderLocation))
                Directory.CreateDirectory(folderLocation);

            string filePath = Path.Combine(folderLocation, fileName);

            using FileStream stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }
    }
}
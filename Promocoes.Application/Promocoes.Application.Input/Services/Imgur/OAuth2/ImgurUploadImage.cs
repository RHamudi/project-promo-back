using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Imgur.API.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;

namespace Promocoes.Application.Input.Services.Imgur.OAuth2
{
    public class ImgurUploadImage
    {
        public async static Task<IImage> UploadImage(ImageEndpoint endpoint,IFormFile image)
        {
            var filePath = Path.Combine("Storage", image.FileName);
            FileStream fileSave;
            using (fileSave = new(filePath, FileMode.Create))
            {
                image.CopyTo(fileSave);
            }
            using var fileStream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var imageUpload = await endpoint.UploadImageAsync(fileStream);
            File.Delete(filePath);    

            return imageUpload;
        }
    }
}
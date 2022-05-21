using Microsoft.AspNetCore.Http;

namespace Catalog.Application.Common.Models
{
    public static class Helper
    {
        public static string ConvertFileToBase64(IFormFile file)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                file.CopyTo(mStream);
                var fileBytes = mStream.ToArray();
                return Convert.ToBase64String(fileBytes);
            }
        }
    }
}
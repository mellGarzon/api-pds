using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace PDS.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        public FileController()
        {
        }

        private static string GenerateSecureSignature(string secretKey, string expire)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                var data = Encoding.UTF8.GetBytes(expire);
                var signatureBytes = hmac.ComputeHash(data);
                var signature = BitConverter.ToString(signatureBytes).Replace("-", "").ToLower();
                return signature;
            }
        }

        public async Task<string> UploadToUploadcare(IFormFile file)
        {
            string apiUrl = "https://upload.uploadcare.com/base/";
            string publicKey = "c24b36a46c495fa1c850";
            string secretKey = "78b31e6a10145466bc62";

            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var fileBytes = ms.ToArray();

                var expire = "never"; 
                var signature = GenerateSecureSignature(secretKey, expire);

                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Add("Authorization", $"Uploadcare.Simple {publicKey}:{secretKey}");
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(publicKey), "UPLOADCARE_PUB_KEY");
                content.Add(new StringContent(signature), "signature");
                content.Add(new StringContent(expire), "expire");
                content.Add(new ByteArrayContent(fileBytes), "file", file.FileName);

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                else
                {
                    return "Erro ao fazer upload do arquivo.";
                }
        }
    }

}
}

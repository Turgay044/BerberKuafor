using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace BerberKuafor.Controllers
    {
        public class AIController : Controller
        {
            private readonly IHttpClientFactory _clientFactory;
            private readonly IConfiguration _configuration;

            public AIController(IHttpClientFactory clientFactory, IConfiguration configuration)
            {
                _clientFactory = clientFactory;
                _configuration = configuration;
            }

            [HttpGet]
            public IActionResult UploadPhoto()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> UploadPhoto(IFormFile file)
            {
                if (file == null || file.Length == 0)
                {
                    ModelState.AddModelError("", "Lütfen bir dosya yükleyin.");
                    return View();
                }
            var apiUrl = _configuration["AISettings:ApiUrl"];
            var apiKey = _configuration["AISettings:ApiKey"];

            var content = new MultipartFormDataContent();

                try
                {
                    // Dosyayı ekleyin
                    var fileStream = file.OpenReadStream();
                    var fileContent = new StreamContent(fileStream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                    content.Add(fileContent, "file", file.FileName);

                    // API anahtarını ekleyin
                    content.Add(new StringContent(apiKey), "api_key");

                    // İstek gönderin
                    var client = _clientFactory.CreateClient();
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        dynamic parsedResult = JsonSerializer.Deserialize<dynamic>(result);
                    
                    Console.WriteLine($"API Yanıtı: {result}");
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Hatası: {errorContent}");
                    ModelState.AddModelError("", $"API Hatası: {errorContent}");
                    // Verileri kontrol ederek ViewBag'e atama
                    ViewBag.SuggestedPhotoUrl = parsedResult?["SuggestedPhotoUrl"]?.ToString();
                        ViewBag.RecommendationDetails = parsedResult?["RecommendationDetails"]?.ToString();

                        if (string.IsNullOrEmpty(ViewBag.SuggestedPhotoUrl))
                        {
                            ModelState.AddModelError("", "API geçerli bir sonuç döndürmedi.");
                        }
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError("", $"API Hatası: {errorContent}");
                    }

                    return View();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Bir hata oluştu: {ex.Message}");
                    return View();
                }
                finally
                {
                    content?.Dispose();
                }
            }
        }
    }

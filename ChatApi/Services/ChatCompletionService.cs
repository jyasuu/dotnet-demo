using ChatApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ChatApi.Services
{
    public class ChatCompletionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _authorizationToken;
        private readonly ILogger _logger;


        // Inject IConfiguration to read the token from appsettings.json
        public ChatCompletionService(ILogger<ChatCompletionService> logger,HttpClient httpClient, IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = httpClient;
            _authorizationToken = configuration["ApiSettings:AuthorizationToken"];
        }

        public async Task<ChatResponse> GetChatCompletionAsync(ChatRequest chatRequest)
        {
            // Set the API URL
            var url = "https://api.x.ai/v1/chat/completions";
            // url = "http://localhost:5036/v1/chat/completions";

            // Serialize the request body to JSON
            var jsonContent = JsonConvert.SerializeObject(chatRequest);
            _logger.LogInformation(jsonContent);
            _logger.LogInformation($"Bearer {_authorizationToken}");

            var content = new StringContent(
                jsonContent,
                Encoding.UTF8,
                Application.Json);

            // Add Authorization header
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_authorizationToken}");

            // Send the POST request
            var response = await _httpClient.PostAsync(url, content);

            // Check if the response is successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            var responseContent = await response.Content.ReadAsStringAsync();

            // Deserialize the response to our model
            return JsonConvert.DeserializeObject<ChatResponse>(responseContent);
        }
    }
}

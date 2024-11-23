using ChatApi.Models;
using ChatApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatCompletionController : ControllerBase
    {
        private readonly ChatCompletionService _chatCompletionService;

        public ChatCompletionController(ChatCompletionService chatCompletionService)
        {
            _chatCompletionService = chatCompletionService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatRequest chatRequest)
        {
            if (chatRequest == null)
            {
                return BadRequest("Request body cannot be null");
            }

            var response = await _chatCompletionService.GetChatCompletionAsync(chatRequest);

            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGptController : ControllerBase
    {
        private readonly OpenAiService _openAiService;

        public ChatGptController(OpenAiService openAiService)
        {
            _openAiService = openAiService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendPrompt([FromBody] string prompt)
        {
            var response = await _openAiService.GetChatGptResponse(prompt);
            return Ok(response);
        }
    }
}

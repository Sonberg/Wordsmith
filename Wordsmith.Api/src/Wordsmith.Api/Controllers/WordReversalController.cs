namespace Wordsmith.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Wordsmith.Api.Models;
    using Wordsmith.Core.Services;

    [ApiController]
    [Route("word-reversal")]
    public class WordReversalController : ControllerBase
    {
        private readonly ILogger<WordReversalController> _logger;

        private readonly IWordReversalService _wordReversalService;

        private readonly IConfiguration _configuration;

        public WordReversalController(ILogger<WordReversalController> logger, IWordReversalService wordReversalService, IConfiguration configuration)
        {
            _logger = logger;
            _wordReversalService = wordReversalService;
            _configuration = configuration;
        }

        [HttpGet("config")]
        public string Config()
        {

            return _configuration.GetValue<string>("Database");
        }

        [HttpPost]
        public async Task<WordReversalResponse> Post([FromBody] WordReversalRequest request, CancellationToken cancellationToken)
        {

            return new WordReversalResponse
            {
                Input = request.Value,
                Reversed = await _wordReversalService.Transform(request.Value, cancellationToken)

            };
        }
    }
}


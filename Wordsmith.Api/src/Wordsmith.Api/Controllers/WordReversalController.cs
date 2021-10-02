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

        public WordReversalController(ILogger<WordReversalController> logger, IWordReversalService wordReversalService)
        {
            _logger = logger;
            _wordReversalService = wordReversalService;
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


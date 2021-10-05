namespace Wordsmith.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Wordsmith.Api.Models;
    using Wordsmith.Core.Services;

    [ApiController]
    [Route("word-reversal")]
    public class WordReversalController : ControllerBase
    {
        private readonly IWordReversalService _wordReversalService;

        public WordReversalController(IWordReversalService wordReversalService)
        {
            _wordReversalService = wordReversalService;
        }

        [HttpGet]
        public string Get()
        {

            return "";
        }

        [HttpPost]
        public async Task<WordReversalResponse> Post([FromBody] WordReversalRequest request, CancellationToken cancellationToken)
        {
            var transformation = await _wordReversalService.Transform(request.Input, cancellationToken);

            if (transformation == null) {
                throw new BadHttpRequestException("Value cannot be transformed");
            }

            return WordReversalResponse.From(transformation);
        }
    }
}


using BackendChallenge.Models;
using BackendChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.Controllers
{
    [ApiController]
    [Route("api/form")]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;
        private readonly ILogger<FormController> _logger;

        public FormController(IFormService formService, ILogger<FormController> logger)
        {
            _formService = formService;
            _logger = logger;
        }

        [HttpPost(Name = "PostForm")]
        public async Task<IActionResult> Post([FromForm] FormRequest formRequest)
        {
            
            var createdForm = await _formService.CreateFormAsync(
                formRequest.Email,
                formRequest.FirstName,
                formRequest.SecondName,
                formRequest.Comment,
                formRequest.File
            );

            return Ok(createdForm);
        }

    }
}

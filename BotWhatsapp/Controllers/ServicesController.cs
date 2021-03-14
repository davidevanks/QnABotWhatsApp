using BotWhatsapp.Services.QnAMakerAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotWhatsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private IQnAMakerAPIService _qnAMakerAPIService;
        public ServicesController(IQnAMakerAPIService qnAMakerAPIService)
        {
            _qnAMakerAPIService = qnAMakerAPIService;
        }

        [HttpGet("test")]
        public IActionResult Get() 
        {
            return Ok("test dev ok");
        }

        [HttpGet("qnamaker")]
        public async Task<IActionResult> GetQnAMaker(string message)
        {
            var result = await _qnAMakerAPIService.Execute(message);
            return Ok(result);
        }
    }
}

using BotWhatsapp.Services.QnAMakerAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace BotWhatsapp.Controllers
{
    [Route("api/whatsapp")]
   
    public class whatsappController : TwilioController
    {
        private IQnAMakerAPIService _qnAMakerAPIService;
        public whatsappController(IQnAMakerAPIService qnAMakerAPIService)
        {
            _qnAMakerAPIService = qnAMakerAPIService;
        }

        [HttpPost("message")]
        public async Task<TwiMLResult> MessageAsync(SmsRequest input)
        {
            var response = new MessagingResponse();
            string textUser = input.Body;

            string textBot= await _qnAMakerAPIService.Execute(textUser);
            response.Message(textBot);
            return TwiML(response);
        }
    }
}

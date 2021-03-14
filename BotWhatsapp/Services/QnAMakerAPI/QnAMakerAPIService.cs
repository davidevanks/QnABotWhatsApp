using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotWhatsapp.Services.QnAMakerAPI
{
    public class QnAMakerAPIService: IQnAMakerAPIService
    {
        public async Task<string> Execute(string query)
        {
            string Host = "https://botwhatsappdemo-qnamaker.azurewebsites.net/qnamaker";
            string KbId = "/knowledgebases/908c9479-c946-4a59-99de-0e4433bb90f5/generateAnswer";
            string Authorization = "EndpointKey bbdc8a24-00fc-4367-b4e8-7c8ab6fa56f2";

            var client = new RestClient(Host + KbId);
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", Authorization);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json","{\"question\": \""+ query +"\"}",ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);

            var answer = JsonConvert.DeserializeObject<QnAMakerAPIModel>(response.Content);

            if (answer.Answers.Count>0)
            {
                var answerBot = answer.Answers[0].Answer;
                var score = answer.Answers[0].Score;

                if (score < 40 || answerBot.ToLower().Equals("no good match found in kb."))
                    return "Lo siento, pero no puedo entenderte, prueba con otra pregunta";
                else
                    return answerBot;
                
            }
            else
            {
                return "Lo siento, pero no puedo entenderte, prueba con otra pregunta";
            }
        }
    }
}

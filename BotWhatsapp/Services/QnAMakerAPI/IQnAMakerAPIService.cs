using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotWhatsapp.Services.QnAMakerAPI
{
    public interface IQnAMakerAPIService
    {
        Task<string> Execute(string query);
    }
}

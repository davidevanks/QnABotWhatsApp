using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotWhatsapp.Services.QnAMakerAPI
{
    public class QnAMakerAPIModel
    {
        public IList<Answers> Answers { get; set; }
    }

    public class Answers
    {
        public IList<string> Questions { get; set; }
        public string Answer { get; set; }
        public double Score { get; set; }

    }
}

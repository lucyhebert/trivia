using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    interface IQuestionsRepository
    {
        List<string> GetQuestions(String category, int number);
    }
}

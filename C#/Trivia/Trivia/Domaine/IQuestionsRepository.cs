using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public interface IQuestionsRepository
    {
        LinkedList<string> GetQuestions(String category, int number);
    }
}

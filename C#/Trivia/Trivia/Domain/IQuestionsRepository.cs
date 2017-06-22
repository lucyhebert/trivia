using System;
using System.Collections.Generic;

namespace Trivia.Domain
{
    public interface IQuestionsRepository
    {
        LinkedList<string> GetQuestions(String category, int number);
    }
}

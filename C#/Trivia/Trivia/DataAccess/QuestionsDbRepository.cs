using System;
using System.Collections.Generic;
using Trivia.Domain;

namespace Trivia.DataAccess
{
    public class QuestionsDbRepository : IQuestionsRepository
    {
        public LinkedList<string> GetQuestions(string category, int number)
        {
            throw new NotImplementedException();
        }
    }
}

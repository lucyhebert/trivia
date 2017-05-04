using System;
using System.Collections.Generic;

namespace Trivia
{
    public class QuestionsFromScratchRepository : IQuestionsRepository
    {


        public LinkedList<string> GetQuestions(string category, int number)
        {
            LinkedList<string> QuestionsList = new LinkedList<string>();
            for (int i = 0; i < number; i++)
            {
                QuestionsList.AddLast(category + " Question " + i);
            }
            return QuestionsList;
        }
    }
}

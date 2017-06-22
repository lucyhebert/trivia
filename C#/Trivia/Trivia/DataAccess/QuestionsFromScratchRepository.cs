using System;
using System.Collections.Generic;

namespace Trivia
{
    public class QuestionsFromScratchRepository : IQuestionsRepository
    {


        public LinkedList<string> GetQuestions(string category, int number)
        {
            LinkedList<string> questionsList = new LinkedList<string>();
            for (int i = 0; i < number; i++)
            {
                questionsList.AddLast(category + " Question " + i);
            }
            return questionsList;
        }
    }
}

using System.Collections.Generic;
using Trivia.Domain;

namespace Trivia.DataAccess
{
    public class QuestionsFileRepository : IQuestionsRepository
    {
        public LinkedList<string> GetQuestions(string category, int number)
        {
            string fileName = @"F:\LP_DEVOPS\dotNet\trivia\C#\Trivia\Trivia.Tests\" + category + ".txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);

            LinkedList<string> questionsList = new LinkedList<string>(lines);

            return questionsList;

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Trivia
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

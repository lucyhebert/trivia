using System;
using System.Collections.Generic;

namespace Trivia
{
    public class QuestionsStack
    {
        private string CategoryName { get; set; }

        private LinkedList<string> QuestionsList { get; set; }

        public QuestionsStack(string categoryName)
        {
            CategoryName = categoryName;
            QuestionsList = new LinkedList<string>();

            for (int i = 0; i < 50; i++)
            {
                QuestionsList.AddLast(CategoryName + " Question " + i);
            }
        }

        public void AskQuestion()
        {
            Console.WriteLine("The category is " + CategoryName);
            Console.WriteLine(QuestionsList.First);
            QuestionsList.RemoveFirst();
        }
    }
}
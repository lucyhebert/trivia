using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Questions
    {
        private List<QuestionsStack> Stacks { get; set; }

        public Questions()
        {
            Stacks = new List<QuestionsStack>
            {
                new QuestionsStack("Rock"),
                new QuestionsStack("Sports"),
                new QuestionsStack("Science"),
                new QuestionsStack("Pop")
            };
        }

        public QuestionsStack CurrentCategory(int index)
        {
            return Stacks[index % 4]; 
        }

        public void AskQuestion(int index)
        {
            Console.WriteLine("The category is " + CurrentCategory(index));
            Console.WriteLine(CurrentCategory(index).QuestionList.First);
            CurrentCategory(index).QuestionList.RemoveFirst();
        }
    }
}
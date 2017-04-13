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

        private QuestionsStack CurrentStack(int index)
        {
            return Stacks[index % 4]; 
        }

        public void AskQuestion(int index)
        {
            CurrentStack(index).AskQuestion();
        }
    }
}
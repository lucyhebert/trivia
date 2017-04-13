using System.Collections.Generic;

namespace Trivia
{
    public class Questions
    {
        public List<QuestionsStack> Stacks { get; private set; }

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
    }
}
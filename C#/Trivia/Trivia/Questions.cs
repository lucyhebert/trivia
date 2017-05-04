using System.Collections.Generic;

namespace Trivia
{
    public class Questions
    {
        private List<QuestionsStack> Stacks { get; set; }

        public Questions(List<string> categoriesList )
        {
            if (categoriesList.Count == 0)
            {
                Stacks = new List<QuestionsStack>
                {
                    new QuestionsStack("Pop"),
                    new QuestionsStack("Science"),
                    new QuestionsStack("Sports"),
                    new QuestionsStack("Rock")
                };
            }
            else
            {
                Stacks = new List<QuestionsStack>();
                foreach (var category in categoriesList)
                {
                    Stacks.Add(new QuestionsStack(category));
                }
            }
        }

        private QuestionsStack CurrentStack(int playerPlace)
        {
            return Stacks[playerPlace % Stacks.Count]; 
        }

        public string[] AskQuestion(int playerPlace)
        {
            string[] result = new string[2];
            result[0] = CurrentStack(playerPlace).GetCategoryName();
            result[1] = CurrentStack(playerPlace).GetQuestion();
            CurrentStack(playerPlace).RemoveQuestion();
            return result;
        }
    }
}
using System.Collections.Generic;

namespace Trivia
{
    public class QuestionsStack
    {
        public string CategoryName { get; set; }

        public List<string> QuestionList { get; set; }

        public QuestionsStack(string categoryName)
        {
            CategoryName = categoryName;
            QuestionList = new List<string>();

            for (int i = 0; i < 50; i++)
            {
                QuestionList.Add(CategoryName + " Question " + i);
            }
        }
    }
}
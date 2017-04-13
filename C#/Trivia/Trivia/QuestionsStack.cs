using System.Collections.Generic;

namespace Trivia
{
    public class QuestionsStack
    {
        public string CategoryName { get; set; }

        public LinkedList<string> QuestionList { get; set; }

        public QuestionsStack(string categoryName)
        {
            CategoryName = categoryName;
            QuestionList = new LinkedList<string>();

            for (int i = 0; i < 50; i++)
            {
                QuestionList.AddLast(CategoryName + " Question " + i);
            }
        }
    }
}
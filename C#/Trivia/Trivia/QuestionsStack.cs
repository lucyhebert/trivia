using System.Collections.Generic;
using System.Linq;

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
                AddQuestion(i);
            }
        }

        private void AddQuestion(int i)
        {
            QuestionsList.AddLast(CategoryName + " Question " + i);
        }

        public string GetQuestion()
        {
            return QuestionsList.First();
        }

        public string GetCategoryName()
        {
            return CategoryName;
        }

        public void RemoveQuestion()
        {
            QuestionsList.RemoveFirst();
        }
    }
}
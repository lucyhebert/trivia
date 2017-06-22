using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionsStack
    {
        private string CategoryName { get; set; }

        private LinkedList<string> QuestionsList { get; set; }

        public QuestionsStack(string categoryName, IQuestionsRepository repository)
        {
            CategoryName = categoryName;

            QuestionsList = repository.GetQuestions(categoryName, 50);
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
using System.Collections.Generic;

namespace Trivia
{
    public class Category
    {
        public string CategoryName { get; set; }

        public LinkedList<string> QuestionList { get; set; }

        public Category(string name)
        {
            CategoryName = name;
            QuestionList = new LinkedList<string>();

            for (int i = 0; i < 50; i++)
            {
                QuestionList.AddLast(CategoryName + " Question " + i);
            }
        }
    }
}
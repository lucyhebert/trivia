using System.Collections.Generic;

namespace Trivia
{
    public class Category
    {
        public string CategoryName { get; set; }

        public LinkedList<string> QuestionList { get; set; }

        public Category(string name)
        {
            this.CategoryName = name;
            this.QuestionList = new LinkedList<string>();

            for (int i = 0; i < 50; i++)
            {
                this.QuestionList.AddLast(this.CategoryName + " Question " + i);
            }
        }
    }
}
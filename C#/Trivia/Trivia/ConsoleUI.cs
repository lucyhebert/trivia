using System;

namespace Trivia
{
    public class ConsoleUI : IQuestionUI
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
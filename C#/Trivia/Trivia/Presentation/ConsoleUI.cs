using System;
using Trivia.Domain;

namespace Trivia.Presentation
{
    public class ConsoleUI : IQuestionUI
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
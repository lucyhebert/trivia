using System;
using System.IO;
using NFluent;
using NUnit.Framework;

namespace Trivia.Tests
{
    class QuestionsShould
    {
        [Test]
        public void AllowFourCategories()
        {
            var questions = new Questions();

            Check.That((questions.AskQuestion(0))[0]).Matches(".*Rock.*");
            Check.That((questions.AskQuestion(4))[0]).Matches(".*Rock.*");
        }

        [Test]
        public void AllowFiveCategories()
        {
            var questions = new Questions();

            Check.That((questions.AskQuestion(0))[0]).Matches(".*Rock.*");
            Check.That((questions.AskQuestion(4))[0]).DoesNotMatch(".*Rock.*");
        }
    }
}

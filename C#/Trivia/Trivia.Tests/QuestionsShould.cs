using System;
using System.Collections.Generic;
using System.IO;
using NFluent;
using NUnit.Framework;
using Trivia.DataAccess;
using Trivia.Domain;

namespace Trivia.Tests
{
    class QuestionsShould
    {
        [Test]
        public void AllowFourCategories()
        {
            QuestionsFromScratchRepository repository = new QuestionsFromScratchRepository();

            List<String> categories = new List<string>();
            var questions = new Questions(categories, repository);

            Check.That((questions.AskQuestion(0))[0]).Matches(".*Pop.*");
            Check.That((questions.AskQuestion(4))[0]).Matches(".*Pop.*");
        }

        [Test]
        public void AllowFiveCategories()
        {
            QuestionsFromScratchRepository repository = new QuestionsFromScratchRepository();

            List<String> categories = new List<string>();
            categories.Add("Rock");
            categories.Add("Sports");
            categories.Add("Sciences");
            categories.Add("Pop");
            categories.Add("Histoire");
            var questions = new Questions(categories, repository);

            Check.That((questions.AskQuestion(0))[0]).Matches(".*Rock.*");
            Check.That((questions.AskQuestion(4))[0]).DoesNotMatch(".*Rock.*");
            Check.That((questions.AskQuestion(4))[0]).Matches(".*Histoire.*");
        }
    }
}

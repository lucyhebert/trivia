using NFluent;
using NUnit.Framework;

namespace Trivia.Tests
{
    class QuestionsFileRepositoryShould
    {
        [Test]
        public void GetQuestionsFromFileNamedAccordingCategory()
        {
            var questionsFileRepository = new QuestionsFileRepository();

            var questions = questionsFileRepository.GetQuestions("Pop", 50);

            Check.That(questions).HasSize(50);
            Check.That(questions).Contains("Pop Question 2");
        }
    }
}

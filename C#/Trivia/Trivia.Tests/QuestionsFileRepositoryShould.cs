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

            var questions = questionsFileRepository.GetQuestions("Pop", 3);

            Check.That(questions).HasSize(3);
            Check.That(questions).Contains("Question test 2");
        }
    }
}

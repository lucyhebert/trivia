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

            var questions = questionsFileRepository.GetQuestions("Pop", 1);

            Check.That(questions).HasSize(1);
            Check.That(questions).ContainsExactly("Question test");
        }
    }
}

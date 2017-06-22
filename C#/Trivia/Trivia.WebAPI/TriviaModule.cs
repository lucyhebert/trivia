using System;
using System.Collections.Generic;
using Nancy.ModelBinding;
using Trivia.DataAccess;
using Trivia.Domain;
using Trivia.Presentation;

namespace Trivia.WebAPI
{
    public class TriviaModule : Nancy.NancyModule
    {
        public TriviaModule()
        {
            Post["/newGame"] = NewGame;
        }

        private dynamic NewGame(dynamic o)
        {
            var newGame = this.Bind<NewGame>();

            var repository = new QuestionsFromScratchRepository();
            var questionUi = new WebUI();

            var players = new Players(questionUi);

            foreach (var userName in newGame.UserNames)
            {
                players.AddAPlayer(userName);
            }

            List<string> categories = newGame.QuestionCategories;

            var questions = new Questions(categories, repository);

            var aGame = new Game(players, questions, questionUi);
            
            return questionUi.Message;
        }
    }

    internal class WebUI : IQuestionUI
    {

        public void Display(string message)
        {
            Message += message + "\n";
        }

        public string Message { get; set; }
    }

    public class NewGame
    {
        public List<string> UserNames { get; set; }
        public List<string> QuestionCategories { get; set; }
    }

}

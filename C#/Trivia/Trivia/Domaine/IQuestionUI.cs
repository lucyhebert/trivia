using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Trivia
{
    public interface IQuestionUI {

        void Display(string message);
    }
}
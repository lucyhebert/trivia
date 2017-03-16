using System;
using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace Trivia.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class GoldenMaster
    {
        [Test]
        public void ShouldNotChange()
        {
            var stringWriter = new StringWriter();
            var previouConsoleOut = Console.Out;
            Console.SetOut(stringWriter);
            GameRunner.Main(null);
            Console.SetOut(previouConsoleOut);
            Approvals.Verify(stringWriter.ToString());
        }
    }
}

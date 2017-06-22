using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace Trivia.WebAPI
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = parameters => "Hello World";
        }
    }
}

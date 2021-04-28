using System;
using System.IO;
using System.Text;
using System.Threading;

namespace AgentGame
{
    // Source code: https://gist.github.com/joshschmelzle/610451c749dd14bb777a
    // Thanks to open source <3
    
    class TypeWriter : System.IO.TextWriter
    {
        private TextWriter originalOut;

        public TypeWriter()
        {
            originalOut = Console.Out;
        }

        public override void WriteLine(string message)
        {
            foreach (char c in message)
            {
                originalOut.Write(c);

                if (!Console.KeyAvailable)
                {
                    Thread.Sleep(25);
                }
            }

            if (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            //Animate();

            if (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            originalOut.WriteLine();
        }

        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
    }
}
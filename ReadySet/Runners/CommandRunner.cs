using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ReadySet.Runners
{
    class CommandRunner : Core.IRunner
    {
        public void Run(string command)
        {
            Process.Start(command);
        }

        public string Prompt
        {
            get { return "cmd"; }
        }

        public string Name
        {
            get { return "Command Runner"; }
        }

        public bool HasOutput
        {
            get { return false; }
        }


        public async Task<string[]> RunAsync(string command)
        {
            throw new NotImplementedException();
        }
    }
}

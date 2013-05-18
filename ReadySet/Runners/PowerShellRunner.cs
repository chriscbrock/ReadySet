using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace ReadySet.Runners
{
    class PowerShellRunner : Core.IRunner
    {
        public void Run(string command)
        {
            throw new NotImplementedException();
        }

        public string Prompt
        {
            get { return "ps"; }
        }

        public string Name
        {
            get { return "Powershell Runner"; }
        }

        public bool Output
        {
            get { return true; }
        }


        public async Task<string[]> RunAsync(string command)
        {
            var shell = PowerShell.Create();

            var result = await Task.Run(() => shell.Invoke(new [] { command }));
            
            return result.Select(r => r.ToString()).ToArray();
        }
    }
}

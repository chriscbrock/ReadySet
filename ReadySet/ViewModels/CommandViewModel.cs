using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace ReadySet.ViewModels
{
    public class CommandViewModel : Core.BaseViewModel
    {
        private Core.IRunner _runner;
        private string _command;
        private bool _commandInputEnabled;

        public CommandViewModel()
        {
            Runner = new Runners.CommandRunner();

            CommandInputEnabled = true;

            // Setup commands
            RunCommand = new ActionCommand(RunAction);
            EscCommand = new ActionCommand(Close);
            SetCmdRunnerCommand = new ActionCommand(SetCmdRunnerAction);
            SetPsRunnerCommand = new ActionCommand(SetPsRunnerAction);
        }

        #region Commands

        public ICommand RunCommand { get; private set; }
        public ICommand EscCommand { get; private set; }
        public ICommand SetCmdRunnerCommand { get; private set; }
        public ICommand SetPsRunnerCommand { get; private set; }
        
        #endregion

        #region Actions

        private void RunAction()
        {
            _runner.Run(_command);

            Close();
        }

        private void SetCmdRunnerAction()
        {
            Runner = new Runners.CommandRunner();
        }

        private void SetPsRunnerAction()
        {
            Runner = new Runners.PowerShellRunner();
        }

        #endregion

        #region Properties

        public string Prompt
        {
            get { return string.Format("{0}>", Runner.Prompt); }
        }

        public string CommandText
        {
            get { return _command; }

            set
            {
                if (_command != value)
                {
                    _command = value;

                    Changed(() => CommandText);
                }
            }
        }

        public bool CommandInputEnabled
        {
            get { return _commandInputEnabled; }
            set
            {
                _commandInputEnabled = value;

                Changed(() => CommandInputEnabled);
            }
        }

        private Core.IRunner Runner
        {
            get { return _runner; }
            set
            {
                _runner = value;

                Changed(() => Prompt);
            }
        }

        #endregion
    }
}

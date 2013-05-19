using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows;

namespace ReadySet.ViewModels
{
    public class CommandViewModel : Core.BaseViewModel
    {
        private Core.IRunner _runner;
        private string _command;
        private string _commandOutput;
        private bool _commandInputEnabled;
        private Visibility _progressBarVisibility;
        private Visibility _outputVisibility;

        public CommandViewModel()
        {
            Runner = new Runners.CommandRunner();

            CommandInputEnabled = true;
            ProgressBarVisibility = Visibility.Collapsed;
            OutputVisibility = Visibility.Collapsed;

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

        private async void RunAction()
        {
            if (_runner.HasOutput)
            {
                ProgressBarVisibility = Visibility.Visible;
                CommandInputEnabled = false;

                string[] output = await _runner.RunAsync(CommandText);

                CommandOutput = string.Join("\n", output);
                OutputVisibility = Visibility.Visible;
                ProgressBarVisibility = Visibility.Collapsed;
            }
            else
            {
                _runner.Run(CommandText);

                Close();
            }
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

        public string CommandOutput
        {
            get { return _commandOutput; }
            set
            {
                _commandOutput = value;

                Changed(() => CommandOutput);
            }
        }

        public Visibility ProgressBarVisibility
        {
            get { return _progressBarVisibility; }
            set
            {
                _progressBarVisibility = value;

                Changed(() => ProgressBarVisibility);
            }
        }

        public Visibility OutputVisibility
        {
            get { return _progressBarVisibility; }
            set
            {
                _outputVisibility = value;

                Changed(() => OutputVisibility);
            }
        }

        /* Private */

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

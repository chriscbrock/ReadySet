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
        private string _prompt;
        private string _command;

        public CommandViewModel()
        {
            _prompt = "cmd";

            // Setup commands
            RunCommand = new ActionCommand(RunAction);
            EscCommand = new ActionCommand(Close);
        }

        #region Commands

        public ICommand RunCommand { get; private set; }
        public ICommand EscCommand { get; private set; }
        
        #endregion

        #region Actions

        public void RunAction()
        {
            Process.Start(CommandText);

            Close();
        }
        
        #endregion

        #region Properties

        public string Prompt
        {
            get { return string.Format("{0}>", _prompt); }

            set
            {
                _prompt = value;

                Changed(() => Prompt);
            }
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

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReadySet.ViewModels
{
    public class CoreMenuViewModel : Core.BaseViewModel
    {
        public CoreMenuViewModel()
        {
            OpenCommand = new ActionCommand(OpenAction);
            AboutCommand = new ActionCommand(AboutAction);
            SettingsCommand = new ActionCommand(SettingsAction);
            HelpCommand = new ActionCommand(HelpAction);
            ExitCommand = new ActionCommand(Close);
        }

        #region Commands

        public ICommand OpenCommand { get; private set; }
        public ICommand AboutCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        public ICommand HelpCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        #endregion

        #region Actions

        public void OpenAction() { (new Views.CommandView()).Show(); }

        public void AboutAction() { }

        public void SettingsAction() { }

        public void HelpAction() { }

        #endregion
    }
}

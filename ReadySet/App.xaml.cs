using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReadySet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Hardcodet.Wpf.TaskbarNotification.TaskbarIcon _icon;

        private void StartApp(object sender, StartupEventArgs e)
        {
            _icon = new Hardcodet.Wpf.TaskbarNotification.TaskbarIcon();
            _icon.ContextMenu = new Views.CoreMenuView();
            _icon.ToolTipText = "ReadySet";

            (_icon.ContextMenu.DataContext as Core.BaseViewModel).CloseRequest += CloseRequested;
        }

        private void CloseRequested(object sender)
        {
            Shutdown();
        }
    }
}

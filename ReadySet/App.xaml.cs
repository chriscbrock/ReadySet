using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReadySet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Hardcodet.Wpf.TaskbarNotification.TaskbarIcon _icon;
        private ViewModels.CoreMenuViewModel _viewModel;
        private Core.GlobalHotKey _hotKey;
        private Mutex _singleAppMutex;

        private void StartApp(object sender, StartupEventArgs e)
        {
            // Check if the app is already running
            var appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value;
            
            _singleAppMutex = new Mutex(false, string.Format(@"Global\{0}", appGuid));

            if (!_singleAppMutex.WaitOne(0, false))
            {
                MessageBox.Show("An instance of ReadySet is already running", "Unable to start ReadySet", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                Shutdown();
            }

            _viewModel = new ViewModels.CoreMenuViewModel();
            
            _icon = new Hardcodet.Wpf.TaskbarNotification.TaskbarIcon();
            _icon.ContextMenu = new Views.CoreMenuView(_viewModel);
            _icon.ToolTipText = "ReadySet";
            _icon.Icon = ReadySet.Properties.Resources.icon_small;

            _viewModel.CloseRequest += CloseRequested;

            _hotKey = new Core.GlobalHotKey(Key.C, Core.KeyModifier.Shift | Core.KeyModifier.Win, HotKeyPressed);
        }

        private void CloseRequested(object sender)
        {
            Shutdown();
        }

        private void HotKeyPressed(Core.GlobalHotKey hotkey)
        {
            _viewModel.OpenAction();
        }
    }
}

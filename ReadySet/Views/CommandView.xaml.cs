using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadySet.Views
{
    public partial class CommandView : Window
    {
        public CommandView()
        {
            InitializeComponent();

            var viewModel = new ViewModels.CommandViewModel();

            // Hookup the event handlers
            viewModel.CloseRequest += CloseRequested;
            viewModel.MessageBoxRequest += MessageBoxRequested;

            DataContext = viewModel;
        }

        void MessageBoxRequested(object sender, Core.BaseViewModel.MessageBoxRequestEventArgs args)
        {
            MessageBoxImage image = MessageBoxImage.None;

            if(args.MessageType == Core.BaseViewModel.MessageType.Error) image = MessageBoxImage.Error;
            else if(args.MessageType == Core.BaseViewModel.MessageType.Info) image = MessageBoxImage.Information;
            else if(args.MessageType == Core.BaseViewModel.MessageType.Warning) image = MessageBoxImage.Warning;

            MessageBox.Show(args.Message, args.Title, MessageBoxButton.OK, image);
        }

        #region Event handlers

        private void CloseRequested(object sender)
        {
            Close();
        }

        #endregion
    }
}

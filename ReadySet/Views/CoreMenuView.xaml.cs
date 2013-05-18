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
    /// <summary>
    /// Interaction logic for CoreMenuView.xaml
    /// </summary>
    public partial class CoreMenuView : ContextMenu
    {
        public CoreMenuView(Core.BaseViewModel viewModel = null)
        {
            InitializeComponent();

            if (viewModel == null)
                DataContext = new ViewModels.CoreMenuViewModel();
            else
                DataContext = viewModel;
        }
    }
}

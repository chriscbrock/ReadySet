﻿using System;
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

            viewModel.CloseRequest += CloseRequested;

            DataContext = viewModel;
        }

        private void CloseRequested(object sender)
        {
            Close();
        }
    }
}

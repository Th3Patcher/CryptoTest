﻿using CryptoTest.ViewModels;
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
using System.Windows.Shapes;

namespace CryptoTest.Views
{
    /// <summary>
    /// Логика взаимодействия для ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        private ShellViewModel _viewModel;
        public ShellView()
        {
            InitializeComponent();

            _viewModel = new ShellViewModel();
            DataContext = _viewModel;

            LoadDataAsync();

        }
        private async void LoadDataAsync()
        {
            var data = await _viewModel.GetDataFromApi();
            CurrencyDataGrid.ItemsSource = data;
        }
    }
}

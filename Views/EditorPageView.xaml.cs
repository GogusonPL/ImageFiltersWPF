﻿using ImageFiltersWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageFiltersWPF.Views
{
    /// <summary>
    /// Interaction logic for EditorPageView.xaml
    /// </summary>
    public partial class EditorPageView : Page
    {
        public EditorPageView(IServiceProvider serviceProvider)
        {
            DataContext = serviceProvider.GetRequiredService<EditorPageViewModel>();
            InitializeComponent();
        }
    }
}

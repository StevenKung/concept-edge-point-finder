using System;
using System.Windows;
using Core.Arch;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using ImageProfiler.ViewModels;
using Presentation.Actions;
using Presentation.Message;
using Presentation.ViewModels;
namespace ImageProfiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private ViewModelActionPanel actionPanel;

		public MainWindow()
        {
			InitializeComponent();
			actionPanel = SimpleIoc.Default.GetInstance<ViewModelActionPanel>();
			TestData();
		}

		private void TestData()
		{
			ElementBaseCollection items = (Canvs.DataContext as ViewModelCanvas).Elements;
			actionPanel.Context.CurrentCoordinate = items[0] as ViewModelCoordinate;
		}
	}
}

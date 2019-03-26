using System;
using System.Windows;
using Core.Arch;
using GalaSoft.MvvmLight.Ioc;
using ImageProfiler.RotedEventType;
using ImageProfiler.ViewModels;
using Presentation.Actions;
using Presentation.ViewModels;
namespace ImageProfiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private ViewModelActionPanel actionPanel = SimpleIoc.Default.GetInstance<ViewModelActionPanel>();

		public MainWindow()
        {
            InitializeComponent();
			actionPanel.ActionLineFree.ViewModelCreated += ActionBase_ViewModelCreated;
			actionPanel.ActionLineFitted.ViewModelCreated += ActionBase_ViewModelCreated;
			actionPanel.ActionGrayImage.ViewModelCreated += ActionBase_ViewModelCreated;
			TestData();
		}

		private void ActionBase_ViewModelCreated(object sender, EventArgs e)
		{
			var data = Canvs.DataContext as ViewModelCanvas;
			data.Elements.Add(sender as ViewModelBase);
		}
		private void TestData()
		{
			ElementBaseCollection items = (Canvs.DataContext as ViewModelCanvas).Elements;
			actionPanel.Context.CurrentCoordinate = items[0] as ViewModelCoordinate;
		}
	}
}

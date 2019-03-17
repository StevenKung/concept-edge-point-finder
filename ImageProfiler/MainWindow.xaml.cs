using System;
using System.Windows;
using Core.Arch;
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
		private ViewModelActionPanel actionPanel =  Application.Current.TryFindResource(nameof(ViewModelActionPanel)) as ViewModelActionPanel;

		public MainWindow()
        {
            InitializeComponent();
			actionPanel.ActionLineFree.ViewModelCreated += ActionBase_ViewModelCreated;
        }

		private void ActionBase_ViewModelCreated(object sender, EventArgs e)
		{
			var data = Canvs.DataContext as ViewModelCanvas;
			data.Elements.Add(sender as ViewModelBase);
		}

		private void UserControlCanvs_ElementSelected(object sender, RoutedEventArgs e)
		{
			ViewModelBase vm = (e as ViewModelSelectedEventArgs).ViewModel;
			
			actionPanel.Context.SelectedViewModels.Add(vm);
		}
	}
}

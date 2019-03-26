using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using ImageProfiler.RotedEventType;
using Presentation.Actions;
using Presentation.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace ImageProfiler.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelMain :INotifyPropertyChanged
    {
		public RelayCommand<RoutedEventArgs> AddSelectionCommand { get; set; }


		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public ViewModelMain()
        {
			////if (IsInDesignMode)
			////{
			////    // Code runs in Blend --> create design time data.
			////}
			////else
			////{
			////    // Code runs "for real"
			////}
			///
			AddSelectionCommand = new RelayCommand<RoutedEventArgs>(AddSelection);

		}

		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Use EventToCommand add selected ViewModel
		/// TODO, may use Messenger instead?
		/// </summary>
		/// <param name="e"></param>
		private void AddSelection(RoutedEventArgs e)
		{
			var actionPanel = SimpleIoc.Default.GetInstance<ViewModelActionPanel>();

			ViewModelBase vm = (e as ViewModelSelectedEventArgs).ViewModel;

			actionPanel.Context.SelectedViewModels.Add(vm);
		}
    }
}
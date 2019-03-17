using ImageProfiler.ViewModels;
using System.Windows;
using System.Windows.Controls;
using Presentation.ViewModels;
using ImageProfiler.RotedEventType;

namespace ImageProfiler.Views
{
	/// <summary>
	/// UserControlCanvs.xaml 的互動邏輯
	/// </summary>
	public partial class UserControlCanvs : UserControl
	{
		private ViewModelCanvas elements = new ViewModelCanvas();
		public UserControlCanvs()
		{

			InitializeComponent();
			this.DataContext = elements;


			Border.MouseMove += Border_MouseMove;
		}

		#region Custeom RoutedEvent

		public static readonly RoutedEvent ViewModelSelectedEvent = EventManager.RegisterRoutedEvent(
			nameof(ViewModelSelected),
			RoutingStrategy.Bubble, typeof(RoutedEventHandler),
			typeof(UserControlCanvs));
		/// <summary>
		/// User have selected one ViewModel in canvas
		/// </summary>
		public event RoutedEventHandler ViewModelSelected
		{
			add { AddHandler(ViewModelSelectedEvent, value); }
			remove { RemoveHandler(ViewModelSelectedEvent, value); }
		}
		void RaiseElementSelectedEvent(ViewModelBase vm)
		{
			ViewModelSelectedEventArgs newEventArgs = new ViewModelSelectedEventArgs(ViewModelSelectedEvent, vm);
			RaiseEvent(newEventArgs);
		}

		#endregion

		private void Border_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			//var point = new PointF((float)Border.PrimaryX, (float)Border.PrimaryY);
			//Idraw obj = model.FindSnapPoint(point);
			//if (obj != null) obj.isSelected = true;
		}

		private void Shap_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var frameworkElement = e.Source as FrameworkElement;
			var target = frameworkElement.DataContext as ViewModelBase;
			target.IsSelected = true;
			RaiseElementSelectedEvent(target);
		}
	}

}

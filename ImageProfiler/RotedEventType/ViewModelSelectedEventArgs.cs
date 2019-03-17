using System.Windows;
using Presentation.ViewModels;

namespace ImageProfiler.RotedEventType
{
	public class ViewModelSelectedEventArgs : RoutedEventArgs
	{

		public ViewModelBase ViewModel { get; }

		public ViewModelSelectedEventArgs(RoutedEvent routedEvent, ViewModelBase VM) : base(routedEvent)
		{
			this.ViewModel = VM;
		}
	}
}

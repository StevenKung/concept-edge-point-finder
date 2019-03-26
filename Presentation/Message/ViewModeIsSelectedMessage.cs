using GalaSoft.MvvmLight.Messaging;
using Presentation.ViewModels;

namespace Presentation.Message
{
	/// <summary>
	/// Send by ViewModelBase after user click object form View
	/// inform OrderContext to store in SelectedViewModels
	/// </summary>
	public class ViewModeIsSelectedMessage : MessageBase
	{
		public ViewModeIsSelectedMessage(ViewModelBase sender) : base(sender) { }
	}
}

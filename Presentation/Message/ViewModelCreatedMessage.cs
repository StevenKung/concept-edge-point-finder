using GalaSoft.MvvmLight.Messaging;
using Presentation.ViewModels;

namespace Presentation.Message
{
	/// <summary>
	/// Carry ViewModel which is created by ActionPanel to inform ViewModelCanvas to store new object
	/// </summary>
	public class ViewModelCreatedMessage : MessageBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender">Passing parameter</param>
		public ViewModelCreatedMessage(ViewModelBase sender) : base(sender) { }
	}
}

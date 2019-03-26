using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Messaging;
using Presentation.Message;
using Core.Arch;

namespace Presentation.ViewModels
{

	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		/// <summary>
		/// The model element held
		/// </summary>
		internal readonly ElementBase m_element;

		public ViewModelBase(ElementBase Element)
		{
			m_element = Element;
			Element.ValueChangedEvent += ElementValueChanged;
		}

		/// <summary>
		/// Get all properties name of ViewModel and RaisePropertyChanged 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void ElementValueChanged(object sender, EventArgs e)
		{
			Type type = this.GetType();
			foreach (var pro in type.GetProperties())
			{
				RaisePropertyChanged(pro.Name);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Greater the value of a given, the more likely the element is to appear in the foreground
		/// </summary>
		public int Zindex { get; set; } = 1;


		private bool m_isSelected = false;

		/// <summary>
		/// View is selected by mouse click
		/// </summary>
		public bool IsSelected
		{
			get { return m_isSelected; }
			set
			{
				m_isSelected = value;
				if (m_isSelected)
					Messenger.Default.Send(new ViewModeIsSelectedMessage(this));
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using Presentation.Message;
using Presentation.ViewModels;

namespace Presentation.Actions
{
    /// <summary>
    /// Composite all actions and order context
    /// As data source to let command bar binding
    /// TODO , what if other need to bind the same instance of this type? how to bind to the same reference?
    /// </summary>
    public class ViewModelActionPanel : INotifyPropertyChanged
    {
        /// <summary>
        /// Properties
        /// </summary>
        public OrderContext Context { get => m_context; }
        public ActionPointFree ActionPointFree { get => m_pointFree; }
        public ActionLineFree ActionLineFree { get => m_lineFree; }
		public ActionLineFitted ActionLineFitted { get => m_lineFitted; }
        public ActionCoordinate ActionCoordinate { get => m_coordinate; }
		public ActionGrayImage ActionGrayImage { get => m_grayImage; }

        internal OrderContext m_context = new OrderContext();

        /// <summary>
        /// Actions
        /// </summary>
        internal ActionPointFree m_pointFree = new ActionPointFree();
        internal ActionLineFree m_lineFree = new ActionLineFree();
		internal ActionLineFitted m_lineFitted = new ActionLineFitted();
        internal ActionCoordinate m_coordinate = new ActionCoordinate();
		internal ActionGrayImage m_grayImage = new ActionGrayImage();

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ViewModelActionPanel()
        {
            m_coordinate.ViewModelCreated += OnCoordinateCreated;

			m_pointFree.ViewModelCreated += ViewModelCreatedMessage;
			m_lineFree.ViewModelCreated += ViewModelCreatedMessage;
			m_lineFitted.ViewModelCreated += ViewModelCreatedMessage;
			m_coordinate.ViewModelCreated += ViewModelCreatedMessage;
			m_grayImage.ViewModelCreated += ViewModelCreatedMessage;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void OnCoordinateCreated(Object sender,EventArgs e)
        {
            var coord = sender as ViewModelCoordinate;
            m_context.AvailableCoordinates.Add(coord);
            m_context.CurrentCoordinate = coord;
        }
		private void ViewModelCreatedMessage(object sender, EventArgs e)
		{
			Messenger.Default.Send(new ViewModelCreatedMessage(sender as ViewModelBase));
		}
    }
}

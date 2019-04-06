using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.ViewModels;
using Core.Derived;
using System.Collections.ObjectModel;

namespace Presentation.Actions
{
	public class ActionPointEdge : ActionBase
	{
		public ActionPointEdge() : base(typeof(ViewModelPoint), typeof(PointEdge)) { }

		internal override bool m_canExecute(ObservableCollection<ViewModelBase> list)
		{
			return list.Any(vm => vm is ViewModelLineBase) && list.Any(vm => vm is ViewModelGrayImage) && list.Count() == 2;
		}
	}
}

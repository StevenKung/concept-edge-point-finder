using System.Linq;
using Presentation.ViewModels;
using Core.Derived;
using System.Collections.ObjectModel;
using Core.Arch;

namespace Presentation.Actions
{
    public class ActionLineFitted : ActionBase
    {
        public ActionLineFitted():base(typeof(ViewModelLineBase),typeof(LineFitted))
        {

        }

        internal override bool m_canExecute(ObservableCollection<ViewModelBase> list)
        {
			return list.Count((ViewModelBase x) =>
			{
				return x.m_element is PointBase;
			}) >= 2;
		}
    }
}

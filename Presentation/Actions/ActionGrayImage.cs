using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using Presentation.ViewModels;
using Core.Arch;
using Core.Derived;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;

namespace Presentation.Actions
{
	public class ActionGrayImage : ActionBase
	{
		public ActionGrayImage() : base(typeof(ViewModelGrayImage), typeof(GrayImage))
		{
		}

		public override bool CanExecute(object parameter)
		{
			OrderContext oc = parameter as OrderContext;

			if (oc == null)
				return false; //bad parameter

			//Nothing cached, can't generate image
			if (oc.CurrentCoordinate == null)
				return false;

			ObservableCollection<ViewModelBase> list = new ObservableCollection<ViewModelBase>() { oc.CurrentCoordinate };
			bool result = m_canExecute(list);
			return result;
		}

		/// <summary>
		/// Always create new and add? how to replace current one?
		/// </summary>
		/// <param name="parameter"></param>
		public override void Execute(object parameter)
		{
			OrderContext oc = parameter as OrderContext;

			//turns into dependecy list
			var dependencies = new List<ElementBase>() { oc.CurrentCoordinate.m_element };

			//generate Model element
			var element = Activator.CreateInstance(m_modelType, dependencies) as GrayImage;

			//treat parameter as a ObservableCollection<ViewModelBase>
			var vm = Activator.CreateInstance(m_viewModelType, element) as ViewModelBase;


			string CombinedPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\");
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*",
				InitialDirectory = Path.GetFullPath(CombinedPath)
			};
			if (openFileDialog.ShowDialog() == false)
				return;
			Cv2.CvtColor(Cv2.ImRead(openFileDialog.FileName), element.Image, ColorConversionCodes.BGR2GRAY);

			//Raise event, pass new-created object to UserControlCanvus , put it on canvus
			RaiseViewModelCreated(vm);

			//after used , reset
			oc.SelectedViewModels.ToList().ForEach(x => x.IsSelected = false);
			oc.SelectedViewModels.Clear();
		}

		internal override bool m_canExecute(ObservableCollection<ViewModelBase> list)
		{
			return true;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Core.Arch;
using Core.Derived;
using OpenCvSharp;
using Presentation.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Presentation.Message;
using System.Linq;

namespace ImageProfiler.ViewModels
{
	public class ViewModelCanvas : INotifyPropertyChanged
	{

		/// <summary>
		/// hold all ElementBase in bag
		/// </summary>
		public ElementBaseCollection Elements { get; set; } = new ElementBaseCollection();

		public ViewModelCanvas()
		{
			Messenger.Default.Register<ViewModelCreatedMessage>(this, StoreElement);
		}

		private void StoreElement(ViewModelCreatedMessage e)
		{
			if (e.Sender is ViewModelGrayImage img)
			{
				var reference = img.ImageElement.CoordinateReference;
				var list = Elements.ToList();
				var same = list.Find(vm => vm is ViewModelGrayImage && (vm as ViewModelGrayImage).ImageElement.CoordinateReference.Equals(reference));
				if (same != null)
				{
					(same as ViewModelGrayImage).ImageElement.Image = img.ImageElement.Image;
					return;
				}
			}
			Elements.Add(e.Sender as ViewModelBase);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}



	public class ElementBaseCollection : ObservableCollection<ViewModelBase>
	{

		public void AddRange(IList<ViewModelBase> list)
		{
			foreach (var item in list)
				Add(item);
		}

		public void EnvelopElements(IList<ElementBase> list)
		{
			foreach (var item in list)
			{
				Add(ViewModelFactory.CreateViewModel(item));
			}
		}

		public void EnvelopElement(ElementBase element)
		{
			Add(ViewModelFactory.CreateViewModel(element));
		}

		public void ForEach(Action<ViewModelBase> action)
		{
			foreach (var item in this)
			{
				action(item);
			}
		}

		public List<ViewModelBase> ToList()
		{
			var list = new List<ViewModelBase>();
			foreach (var item in this)
			{
				list.Add(item);
			}
			return list;
		}

		#region TestonView

		PointBase p2;
		public ElementBaseCollection()
		{
			CoordinateBase c1 = new CoordinateBase();
			PointBase p1 = new PointBase(new List<ElementBase> { c1 });
			p2 = new PointBase(new List<ElementBase> { c1 });
			PointBase p3 = new PointBase(new List < ElementBase >{ c1});

			p1.Point = new Mat(3, 1, MatType.CV_64FC1, new double[] { 100, 100, 1 });
			p2.Point = new Mat(3, 1, MatType.CV_64FC1, new double[] { 200, 200, 1 });
			p3.Point = new Mat(3, 1, MatType.CV_64FC1, new double[] { 300, 300, 1 });

			LineBase line = new LineBase(new List<ElementBase>() { p1, p2 });

			// items sequence affact ZIndex in itemsControl
			EnvelopElements(new List<ElementBase>() { c1, p1, p2, p3 });
		}

		#endregion
	}




}

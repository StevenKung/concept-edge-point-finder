﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Arch;
using OpenCvSharp;

namespace Core.Derived
{
    /// <summary>
    /// The image , (0,0) attached on previous reference frame
    /// </summary>
    public class GrayImage : ElementBase
    {
        /// <summary>
        /// Image loading interface
        /// </summary>
        public Mat Image
        {
            get { return m_image; }
            set
            {
                m_image = value;
                //https://stackoverflow.com/questions/282653/checking-for-null-before-event-dispatching-thread-safe
                OnValueChanged(this, null);
            }
        }
        
        internal Mat m_image = new Mat();

        public GrayImage(List<ElementBase> dependencies) : base(dependencies)
        {
            //no reference other than coordinate
            m_coordinateReference = (m_dependencies.First() as CoordinateBase).Node;
        }

		public HierarchyTreeNode<CoordinateBase> CoordinateReference { get => m_coordinateReference; }
	}
}

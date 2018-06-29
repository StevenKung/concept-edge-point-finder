﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WindowsFormsApp2.Interface;
using WindowsFormsApp2.DrawObjects;
namespace WindowsFormsApp2
{
    class Utils
    {

        public static PointF GetIntersectPoint(Idraw shape1, Idraw shape2)
        {
            Type type1 = shape1.GetType();
            Type type2 = shape2.GetType();
            if (type1 == typeof(Line) && type2 == typeof(Line))
            {
                Line line1 = shape1 as Line;
                Line line2 = shape2 as Line;
                return LinesIntersect(line1.__start, line1.__end, line2.__start, line2.__end, false, false);
            }

            return PointF.Empty;


        }

        public static PointF LinesIntersect(Point lp1, Point lp2, Point lp3, Point lp4, bool extendA, bool extendB)
        {
            double x1 = lp1.X;
            double x2 = lp2.X;
            double x3 = lp3.X;
            double x4 = lp4.X;
            double y1 = lp1.Y;
            double y2 = lp2.Y;
            double y3 = lp3.Y;
            double y4 = lp4.Y;
            PointF intersection = PointF.Empty;
            double denominator = ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
            if (denominator == 0) // lines are parallel
                return PointF.Empty;
            double numerator_ua = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3));
            double numerator_ub = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3));
            double ua = numerator_ua / denominator;
            double ub = numerator_ub / denominator;
            // if a line is not extended then ua (or ub) must be between 0 and 1
            if (extendA == false)
            {
                if (ua < 0 || ua > 1)
                    return PointF.Empty;
            }
            if (extendB == false)
            {
                if (ub < 0 || ub > 1)
                    return PointF.Empty;
            }
            if (extendA || extendB) // no need to chck range of ua and ub if check is one on lines 
            {
                intersection.X = Convert.ToSingle(x1 + ua * (x2 - x1));
                intersection.Y = Convert.ToSingle(y1 + ua * (y2 - y1));
                return intersection;
            }
            if (ua >= 0 && ua <= 1 && ub >= 0 && ub <= 1)
            {
                intersection.X = Convert.ToSingle(x1 + ua * (x2 - x1));
                intersection.Y = Convert.ToSingle(y1 + ua * (y2 - y1));
                return intersection;
            }

            return PointF.Empty;
        }


    }   //Utils
}   //namespace

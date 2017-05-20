using System;
using System.Collections.Generic;
using System.Drawing;

namespace lab7
{
    public static class Midpoint
    {
        private static OutCode ComputeOutCode(float x, float y, RectangleF r)
        {
            var code = OutCode.Inside;

            if (x < r.Left) code |= OutCode.Left;
            if (x > r.Right) code |= OutCode.Right;
            if (y < r.Top) code |= OutCode.Top;
            if (y > r.Bottom) code |= OutCode.Bottom;

            return code;
        }

        private static OutCode ComputeOutCode(PointF p, RectangleF r)
        {
            return ComputeOutCode(p.X, p.Y, r);
        }

        public static double DistanceBetweenTwoPoints(PointF point1, PointF point2)
        {
            double dx = point1.X - point2.X;
            double dy = point1.Y - point2.Y;
            return Math.Sqrt(dx*dx + dy*dy);
        }

        public static PointF GetMidPointF(PointF p1, PointF p2)
        {
            return new PointF((p2.X + p1.X)/2, (p2.Y + p1.Y)/2);
        }

        
        internal static void ClipSegment(RectangleF bounds, PointF p1, PointF p2, List<Tuple<PointF, PointF>> newLines)
        {
            var outCodeP1 = ComputeOutCode(p1, bounds);
            var outCodeP2 = ComputeOutCode(p2, bounds);
            if (DistanceBetweenTwoPoints(p1, p2) < 1)
            {
                return;
            }
            if ((outCodeP1 & outCodeP2) != 0)
            {
                return;
            }
            if ((outCodeP1 | outCodeP2) == OutCode.Inside)
            {
                newLines.Add(new Tuple<PointF, PointF>(p1, p2));
            }
            ClipSegment(bounds, p1, GetMidPointF(p1, p2), newLines);
            ClipSegment(bounds, GetMidPointF(p1, p2), p2, newLines);
        }


        [Flags]
        private enum OutCode
        {
            Inside = 0,
            Left = 1,
            Right = 2,
            Bottom = 4,
            Top = 8
        }
    }
}
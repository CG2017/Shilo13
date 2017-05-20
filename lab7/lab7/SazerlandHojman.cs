using System;
using System.Collections.Generic;
using System.Drawing;

namespace lab7
{
    public struct Segment
    {
        public readonly PointF A, B;

        public Segment(PointF a, PointF b)
        {
            A = a;
            B = b;
        }        
    }

    public class Polygon : List<PointF>
    {
        public Polygon()
        {
        }

        public Polygon(int capacity)
            : base(capacity)
        {
        }

        public Polygon(IEnumerable<PointF> collection)
            : base(collection)
        {
        }

        public IEnumerable<Segment> Edges
        {
            get
            {
                if (Count >= 2)
                {
                    for (int a = Count - 1, b = 0; b < Count; a = b, ++b)
                    {
                        yield return new Segment(this[a], this[b]);
                    }
                }
            }
        }

        public IEnumerable<Segment> SazerlandHojmanClip(RectangleF bound)
        {
            List<PointF> points = new List<PointF>();
            foreach (Segment seg in Edges)
            {
                bool startIn = IsInside(seg.A, bound);
                bool endIn = IsInside(seg.B, bound);
                if (startIn && endIn)
                {
                    points.Add(seg.A);
                } else if (startIn && !endIn)
                {
                    points.Add(seg.A);
                    var intersectP = CalculateIntersection(bound, seg.A, seg.B, ComputeOutCode(seg.B, bound));
                    points.Add(intersectP);
                } else if (!startIn && endIn)
                {
                    var intersectP = CalculateIntersection(bound, seg.A, seg.B, ComputeOutCode(seg.A, bound));
                    points.Add(intersectP);
                }
            }

            return new Polygon(points).Edges;
        }

        private static PointF CalculateIntersection(RectangleF r, PointF p1, PointF p2, OutCode clipTo)
        {
            var dx = p2.X - p1.X;
            var dy = p2.Y - p1.Y;

            var slopeY = dx / dy; // slope to use for possibly-vertical lines
            var slopeX = dy / dx; // slope to use for possibly-horizontal lines

            if (clipTo.HasFlag(OutCode.Top))
            {
                return new PointF(
                    p1.X + slopeY * (r.Top - p1.Y),
                    r.Top
                    );
            }
            if (clipTo.HasFlag(OutCode.Bottom))
            {
                return new PointF(
                    p1.X + slopeY * (r.Bottom - p1.Y),
                    r.Bottom
                    );
            }
            if (clipTo.HasFlag(OutCode.Right))
            {
                return new PointF(
                    r.Right,
                    p1.Y + slopeX * (r.Right - p1.X)
                    );
            }
            if (clipTo.HasFlag(OutCode.Left))
            {
                return new PointF(
                    r.Left,
                    p1.Y + slopeX * (r.Left - p1.X)
                    );
            }
            throw new ArgumentOutOfRangeException("clipTo = " + clipTo);
        }

        private static bool IsInside(PointF p, RectangleF bound)
        {
            return ComputeOutCode(p, bound) == OutCode.Inside;
        }

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
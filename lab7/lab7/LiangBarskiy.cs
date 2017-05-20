using System;
using System.Drawing;

namespace lab7
{
    public static class LiangBarskiy
    {
        public static Tuple<PointF, PointF> ClipSegment(RectangleF r, PointF P1, PointF P2)
        {
            var dx = P2.X - P1.X;
            var dy = P2.Y - P1.Y;

            float t_In = 0;
            float t_Out = 1;

            Action recount = () =>
            {
                if (t_In > 0)
                {
                    P1.X = P1.X + dx * t_In;
                    P1.Y = P1.Y + dy * t_In;
                }
                if (t_Out < 1)
                {
                    P2.X = P1.X + dx * t_Out;
                    P2.Y = P1.Y + dy * t_Out;
                }
                dx = P2.X - P1.X;
                dy = P2.Y - P1.Y;
                t_In = 0;
                t_Out = 1;
            };

            // Clip_t может модифицировать t_In и t_Out
            // (ref  означает передачу по адресу)
            if (Clip_t(dx, r.Left - P1.X, ref t_In, ref t_Out))
            {
                recount();
                if (Clip_t(-dx, P1.X - r.Right, ref t_In, ref t_Out))
                {
                    recount();
                    if (Clip_t(dy, r.Top - P1.Y, ref t_In, ref t_Out))
                    {
                        recount();
                        if (Clip_t(-dy, P1.Y - r.Bottom, ref t_In, ref t_Out))
                        {
                            recount();
                            return new Tuple<PointF, PointF>(P1, P2);
                        }
                    }
                }
            }
            return null;
        }

        // Проверить пересечение с ребром
        // denom, num - 'знаменатель' и 'числитель' выражения (5.2)
        // t_In и t_Out передаются по адресу (обозначено *),
        // они могут быть модифицированы;
        // возвращает логическую переменную:
        // true - продолжать отcечение
        // false - закончить отcечение,
        // отрезок полностью вне прямоугольника
        static bool Clip_t(float denom, float num, ref float t_In, ref float t_Out)
        {
            float t;
            if (denom > 0) // Потенциально входящее пересечение
            {
                t = num / denom;
                if (t > t_Out)
                    // t_ВхMax > t_ВыхMin: отрезок полностью снаружи
                    return false;
                else if (t > t_In) // Модифицируем t_In
                    t_In = t;
            }
            else if (denom < 0) // Потенциально выходящее пересечение
            {
                t = num / denom;
                if (t < t_In)
                    // t_ВхMax > t_ВыхMin: отрезок полностью снаружи
                    return false;
                else if (t < t_Out) // Модифицируем t_Out
                    t_Out = t;
            }
            else if (num > 0)
                // отрезок параллелен ребру и полностью снаружи
                return false;

            return true;
        }
    }
}
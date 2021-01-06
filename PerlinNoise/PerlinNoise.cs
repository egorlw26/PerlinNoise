using System;

namespace PerlinNoise
{
    internal static class PerlinNoise
    {
        private static double Interpolate(double a0, double a1, double w)
        {
            //return (a1 - a0) * w + a0;
            return (a1 - a0) * (3.0 - w * 2.0) * w * w + a0;
        }

        private static double[] GetRandomVectorAtCell(int x, int y)
        {
            var r = 2920.0 * Math.Sin(x * 21942.0 + y * 171324.0 + 8912.0) * Math.Cos(x * 23157.0 * y * 217832.0 + 9758.0); ;

            // Using cos and sin we get 1-unit-length vector
            return new double[2] { Math.Cos(r), Math.Sin(r) };
        }

        private static double DotVectors(int cx, int cy, double x, double y)
        {
            var vector = GetRandomVectorAtCell(cx, cy);

            var dx = x - cx; // 0-1
            var dy = y - cy; // 0-1

            return dx * vector[0] + dy * vector[1]; // Should be less than 1
        }

        public static double CalcPerlinNoiseAt(double x, double y)
        {
            // Grid cell index
            var cx0 = (int)x;
            var cx1 = cx0 + 1;
            var cy0 = (int)y;
            var cy1 = cy0 + 1;

            var dx = x - cx0;
            var dy = y - cy0;

            var dotx0y0 = DotVectors(cx0, cy0, x, y);
            var dotx1y0 = DotVectors(cx1, cy0, x, y);
            var inty0 = Interpolate(dotx0y0, dotx1y0, dx);

            var dotx0y1 = DotVectors(cx0, cy1, x, y);
            var dotx1y1 = DotVectors(cx1, cy1, x, y);
            var inty1 = Interpolate(dotx0y1, dotx1y1, dx);

            var res = Interpolate(inty0, inty1, dy);

            return res;
        }
    }
}

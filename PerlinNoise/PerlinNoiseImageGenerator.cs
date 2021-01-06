using System.Drawing;

namespace PerlinNoise
{
    internal static class PerlinNoiseImageGenerator
    {
        private static double Map(double value, double fromLow, double fromHigh, double toLow, double toHigh)
        {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }
        public static void DrawAndSave(int width, int height, string fileName)
        {
            var bitmap = new Bitmap(width, height);
            const int gridSize = 30;

            for(int x = 0; x < width; ++x)
            {
                for(int y = 0; y < height; ++y)
                {
                    var mapX = 1.0 * x * gridSize / width;
                    var mapY = 1.0 * y * gridSize / height;
                    
                    var pn = PerlinNoise.CalcPerlinNoiseAt(mapX, mapY);
                    var mappedPn = (int)Map(pn, -1, 1, 0, 255);
                    bitmap.SetPixel(x, y, Color.FromArgb(mappedPn, mappedPn, mappedPn));
                }
            }

            bitmap.Save($"{fileName}.png");
        }
    }
}

using System;

namespace PerlinNoise
{
    class Program
    {
        static void Main(string[] args)
        {
            PerlinNoiseImageGenerator.DrawAndSave(1000, 1000, $"PerlinNoise-{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}");
        }
    }
}

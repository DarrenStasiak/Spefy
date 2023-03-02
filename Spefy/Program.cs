using System;
using SpefyClassLibrary;

namespace Spefy
{
    internal class Program
    {
        static SpotifyService x;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            test();

        }
        public static async void test()
        {
            x = new SpotifyService();
            x.Init();
            await x.GetName("11dFghVXANMlKmJXsNCbNl");


        }


    }
}
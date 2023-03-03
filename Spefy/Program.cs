using System;
using SpefyClassLibrary.Services;

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
            await x.PopulateDatasetPlaylist("49kRPTDZ0q81msXBncY3XO");


        }


    }
}
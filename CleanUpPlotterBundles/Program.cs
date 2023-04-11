using System;
using CleanUpPlotterBundles.Interfaces;
using CleanUpPlotterBundles.Classes;

namespace CleanUpPlotterBundles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hauptverzeichnis der Unterverzeichnise eingeben: ");
            string mainpath = Console.ReadLine();
            CleanUp cleanUp = new CleanUp(new ReadConfig(), new ReadDirectory(), mainpath);

        }
    }
}

using System;
using System.IO;
namespace CafeteriaCard;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        Operations.Defalut();
        Operations.Display();
        Operations.MainMenu();
       // FileHandling.Writecsv();
    }
}

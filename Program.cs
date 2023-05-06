using System.Diagnostics;
using System.Threading;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Cześć, zagramy w szachy. Żeby poznać zasady wpisz \"help\" lub wciśnij enter żeby zagrać.");
        var napis = Console.ReadLine();
        // sprawdz czy nie wpisano help
        Szachownica szachownica = new Szachownica();

        szachownica.wypisz();
        Stopwatch stoper = new Stopwatch();
        stoper.Start();

        while(stoper.Elapsed.TotalSeconds<100)
        {   
            Console.CursorVisible = false;
            Console.SetCursorPosition(0,1);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Pozostały czas: {100-Convert.ToInt32(stoper.Elapsed.TotalSeconds)}s  (aby odświerzyć zerag wciśnij enter)");
            Console.ResetColor();
            Console.SetCursorPosition(0,20);
            Console.CursorVisible = true;

            Console.ReadLine();
        }
        

    }
}
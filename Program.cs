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
        string? napis2;
        int x,y;

        while(stoper.Elapsed.TotalSeconds<100)
        {   
            Console.CursorVisible = false;
            Console.SetCursorPosition(0,1);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Pozostały czas: {100-Convert.ToInt32(stoper.Elapsed.TotalSeconds)}s  (aby odświerzyć zerag wciśnij enter)");
            Console.ResetColor();
            Console.SetCursorPosition(0,21);
            Console.WriteLine("                     ");
            Console.SetCursorPosition(0,21);
            Console.CursorVisible = true;

            napis2 = Console.ReadLine();
            if(napis2!=null)
            {
                string[] cor = napis2.Split(',');
                if( cor.Length==2 && int.TryParse(cor[0], out x) && int.TryParse(cor[1],out y) )
                {
                    break;
                }
            }
        }
        Console.Write("koniec gry");
        Console.Read();
    }
}
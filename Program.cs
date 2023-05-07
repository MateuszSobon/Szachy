using System.Diagnostics;
using System.Threading;
internal class Program
{   
    static public void help()
    {
        Console.WriteLine("Póki co tu nic nie ma, aby wyjść z help wciśnij dowolny klawisz");
        Console.ReadLine();
        Console.Clear();
    }
    static public void edycja_widoku(Stopwatch stoper)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0,1);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"Pozostały czas: {100-Convert.ToInt32(stoper.Elapsed.TotalSeconds)}s  (aby odświerzyć zerag wciśnij enter)   ");
        Console.ResetColor();
        Console.SetCursorPosition(0,21);
        Console.WriteLine("                                                                            ");
        Console.SetCursorPosition(0,21);
        Console.CursorVisible = true;
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Cześć, zagramy w szachy. Żeby poznać zasady wpisz \"help\" lub wciśnij enter żeby zagrać.");
        var napis = Console.ReadLine();
        if (napis=="help")
        {
            help();
        }

        Szachownica szachownica = new Szachownica();
        szachownica.wypisz();

        Stopwatch stoper = new Stopwatch();
        stoper.Start();

        string? napis2;
        int x,y;

        while(stoper.Elapsed.TotalSeconds<100)
        {   
            edycja_widoku(stoper);

            napis2 = Console.ReadLine();
            if(napis2!=null)
            {
                string[] cor = napis2.Split(',');
                if( cor.Length==2 && int.TryParse(cor[0], out x) && int.TryParse(cor[1],out y) )
                {
                    if(x<8 && x>=0 && y<8 && y>=0)
                    {
                        break;   
                    }
                    else
                    {
                        Console.WriteLine(napis2);
                        Console.WriteLine("To nie poprawny zakres wprowadzonych danych, wpisz 2 współrzędne od 0 do 7    ");
                    }
                }
                else
                {
                    Console.WriteLine(napis2);
                    Console.WriteLine("To nie poprawny format wprowadzonych danych, wpisz 2 współrzędne jeszcze raz      ");                    
                }
            }
        }

        Console.WriteLine("koniec gry");
        Console.Read();
    }
}
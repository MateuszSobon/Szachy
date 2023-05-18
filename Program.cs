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
        //Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"Pozostały czas: {100-Convert.ToInt32(stoper.Elapsed.TotalSeconds)}s  (aby odświerzyć zerag wciśnij enter)   ");
        Console.ResetColor();

    }
    public static void wczytaj(Szachownica szachownica)
    {
        Stopwatch stoper = new Stopwatch();
        stoper.Start();

        string? napis;
        int x,y;

        while(stoper.Elapsed.TotalSeconds<100)
        {   
            edycja_widoku(stoper);
            szachownica.wypisz();
            Console.Write("                                             ");
            Console.SetCursorPosition(0,Console.CursorTop);

            napis = Console.ReadLine();
            if(napis!=null)
            {
                string[] cor = napis.Split(',');
                if( cor.Length==2 && int.TryParse(cor[0], out x) && int.TryParse(cor[1],out y) )
                {
                    if((x<8 && x>=0 && y<8 && y>=0) && ((szachownica.tura%2==1 && szachownica.plansza[x,y].kolor==Kolor.biały) ||  (szachownica.tura%2==0 && szachownica.plansza[x,y].kolor==Kolor.czarny)))
                    {   
                        List<List<int>> mat= szachownica.plansza[x,y].ruch(x,y,szachownica.plansza);
                        if(mat.Any())
                        {
                            edycja_widoku(stoper);
                            szachownica.nowa_plansza(x,y);
                            Console.WriteLine("                                                                                                   ");
                            Console.WriteLine("                                                                                                   ");
                            Console.SetCursorPosition(0,Console.CursorTop-2);
                            int xx, yy;

                            napis = Console.ReadLine();
                            if(napis!=null)
                            {
                                string[] cor2 = napis.Split(',');
                                if( cor2.Length==2 && int.TryParse(cor2[0], out xx) && int.TryParse(cor2[1],out yy) )
                                {
                                    if(xx<8 && xx>=0 && yy<8 && yy>=0)
                                    {
                                        szachownica.przesun(x,y,xx,yy);
                                        edycja_widoku(stoper);
                                        szachownica.wypisz();
                                        break;
                                    }
                                    else
                                    {
                                        Console.Write(napis);
                                        Console.WriteLine(": To nie poprawny zakres wprowadzonych danych, wpisz 2 współrzędne od 0 do 7    ");
                                    }
                                }
                                else
                                {
                                    Console.Write(napis);
                                    Console.WriteLine(": To nie poprawny format wprowadzonych danych, wpisz 2 współrzędne jeszcze raz      ");                    
                                }
                            }    
                        }
                        else
                        {
                            Console.Write(napis);
                            Console.WriteLine(": Ta figura nie ma możliwości ruchu");
                        }     
                    }   
                    else
                    {
                        Console.Write(napis);
                        Console.WriteLine(": To nie poprawny zakres wprowadzonych danych, wpisz 2 współrzędne od 0 do 7    ");
                    }
                }
                else
                {
                    Console.Write(napis);
                    Console.WriteLine(": To nie poprawny format wprowadzonych danych, wpisz 2 współrzędne jeszcze raz      ");                    
                }
            }
        }
        if (stoper.Elapsed.TotalSeconds>100)
        {
            Console.WriteLine("Czas się skończył, tracisz ruch");  
        }
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
        Console.Clear();
        wczytaj(szachownica);

        Console.WriteLine("koniec gry");
        Console.Read();
    }
}
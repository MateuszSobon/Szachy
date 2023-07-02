using System.Diagnostics;
using System.Threading; 

// LIST ++++++++++++++++++++++
// funkcjinalność wymuszająca ruch krola ktory może zostać zbity
// tryb gry jednoosobowej
// menu help

internal class Program
{   
    private static void help()
    {   
        string? wybrana;
        int dana;
        Console.WriteLine("\n\nWitaj w helpie. Znajdziesz tutaj zasady i porady dotyczące aplikacji Szachy \n");
        Console.WriteLine("Gra posiada 2 tryby: jednoosobowy i dwuosobowy");
        Console.WriteLine("Aby poczytać o tyrbie 1 os naciśnij \"1\" Aby poczytać o tyrbie 1 os naciśnij \"2\": \n");
        try
        {
            wybrana = Console.ReadLine(); // do poprawy dla bezpieczeństwa
            if (int.TryParse(wybrana, out dana) || dana==1)
            {
                Console.WriteLine("Gra jeszcze niedostępna");
                Console.WriteLine("Aby opuścić help naciśnij dowlolny klawisz");
                Console.ReadLine();
            }
            else if (int.TryParse(wybrana, out dana) || dana==2)
            {
                Console.WriteLine("\n Gra polega na naprzemiennym wybieraniu wpółrzędnych pionków którymi gracz chce się ruszyć. \n  Każdy pionek ma indywidualne możliwości ruchu.\n");
                Console.WriteLine("1: Wybierz pionek którym chcesz się ruszyć");
                Console.WriteLine("2: Podaj jego współrzędne oddzielając je przecinkiem i potwierdz enterem");
                Console.WriteLine("3: Czerwone pola to miejsca gdzie możesz przesunąć figurę");
                Console.WriteLine("4: Po wybraniu pola podaj jego współrzędne oddzielając je przecinkiem i potwierdz enterem");
                Console.WriteLine("5: Tura się zakończy a pionek przesunie w dane miejsce. ");
                Console.WriteLine("   Jeżeli popełniony zostanie błąd w trakcie wpisywania współrzędnych figury \n   lub pola docelowego zostaniesz o tym poinformowany w dolnej części konsoli.");
                Console.WriteLine("   Będziesz mógł poprawić wpisane dane pod warunkiem że nie minęło 100s od czasu rozpoczęcia tury.");
                Console.WriteLine("   Po czasie 100s stracisz ruch. Czas możesz kontrolować w górnej części ekranu. \n   Uwaga aby odświeżyć ekran wystarczy nacisnąć enter");
                Console.WriteLine("6: Zakonćzenie gry następuję gdy jeden z graczy zbije króla przeciwnikowi:");

                Console.WriteLine("\n\nAby opuścić help naciśnij enter ");
                Console.ReadLine();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Brak wyboru \n\nAby opuścić help naciśnij enter ");
                Console.ReadLine();
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Źle wprowadzone dane! Dozwolone tylko 1 lub 2" + ex.Message);
        }

        Console.Clear();
    }
    private static void edycja_widoku(Stopwatch stoper)
    {
        //Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"Pozostały czas: {100-Convert.ToInt32(stoper.Elapsed.TotalSeconds)}s  (aby odświerzyć zerag wciśnij enter)     ");
        Console.ResetColor();

    }
    private static void wczytaj(Szachownica szachownica)
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
            szachownica.tura++;
        }
    }
    
    private static void Main(string[] args)
    {
        Console.WriteLine("Cześć, zagramy w szachy. Żeby poznać zasady wpisz \"help\" lub wybierz tryb gry.");
        Console.WriteLine("Tryb jednoosobowy wciśnij 1 i zatwierdź enterem");
        Console.WriteLine("Tryb dwuosobowy wciśnij 2 i zatwierdź enterem");
        var napis = Console.ReadLine();
        if (napis=="help")
        {
            help();
            Console.WriteLine("Wybierz tryb gry:");
            Console.WriteLine("Tryb jednoosobowy wciśnij 1 i zatwierdź enterem");
            Console.WriteLine("Tryb dwuosobowy wciśnij 2 i zatwierdź enterem");
            napis = Console.ReadLine();
            Console.Clear();
        }
        if(napis=="2")
        {   
            Szachownica szachownica = new Szachownica(); 
            Console.Clear();
            while(szachownica.szach_mat())
            {
                wczytaj(szachownica);
            }

            Console.WriteLine("koniec gry");
            Console.Read();
        }        
        else if(napis=="1")
        {
            Console.WriteLine("Tryb gry jeszcze nie obsługiwany");
            Console.ReadLine(); 
        }
        else
        {
            Console.WriteLine("źle wybrany tryb gry, uruchom gre jeszcze raz");
            Console.ReadLine();  
        }

        

        


    }
}
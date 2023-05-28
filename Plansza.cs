using System.Diagnostics;

class Szachownica
{
    public Figura[,]  plansza = new Figura[8,8]; //public tylk odo testu!

    public int tura {get;set;}  //zlicza ile już tur zosrtało wykonanych, 1-białe, 2-czarne, 3-białe ...

    int pkt_b,pkt_c;
    void jaki_klolor(List<int> val)
    {
        if(plansza[val[0],val[1]].kolor==Kolor.biały)
        {
            Console.ForegroundColor= ConsoleColor.White;
        }
        else 
        {
            Console.ForegroundColor= ConsoleColor.Black;
        }
    }
    public string kto_gra(int t)
    {
        if (t%2==1)
        {
            return "białe";
        }
        else
        {
            return "czarne";
        }
            
    }
    public void nowa_plansza(int x, int y)
    {
        List<List<int>> mat= plansza[x,y].ruch(x,y,plansza);

        wypisz();
        
        int l,p;
        l = Console.CursorLeft;
        p = Console.CursorTop;

        foreach(List<int> val in mat)
        {
            Console.SetCursorPosition(val[1]*4+5, val[0]*2+4);
            Console.BackgroundColor = ConsoleColor.Red;
            jaki_klolor(val);
            if(plansza[val[0],val[1]].nazwa!="   ")
            {
                Console.Write(plansza[val[0],val[1]].nazwa.Replace(" ",""));   
            }
            else
            {
                Console.Write(" ");
            }
            Console.ResetColor();
            Console.SetCursorPosition(l,p);            

        }

    }
    public void przesun(int x, int y, int xx, int yy)
    {   
        List<List<int>> mat= plansza[x,y].ruch(x,y,plansza);

        foreach(List<int> val in mat)
        {
            if(val[0]==xx && val[1]==yy)
            {
                plansza[xx,yy] = plansza[x,y];
                plansza[x,y] = new Puste();
                tura++;
                if(val[2]==1)
                {
                    if(plansza[x,y].kolor==Kolor.czarny)
                    {
                        pkt_c++;
                    }
                    else if (plansza[x,y].kolor==Kolor.biały)
                    {
                        pkt_b++;
                    }
                }    
            }
        }
    }
    public void wypisz()
    {   
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"Tura: {tura}  |  Grają {kto_gra(tura)}  |  Punkty białych: {pkt_b}  |  Punkty czarnych: {pkt_c}");
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Write("  ");

        for(int i=0; i<8; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($" {i}");
        }
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(" |"); 
        Console.WriteLine("\n------------------------------------");
        
        for(int i=0; i<plansza.GetLength(0); i++)
        
        {   
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($" {i}");  
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" |"); 

            for(int j=0; j<plansza.GetLength(1); j++)
            {
                if (plansza[i,j].kolor==Kolor.biały)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (plansza[i,j].kolor==Kolor.czarny)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write(plansza[i,j].nazwa);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("|");
            }
            Console.WriteLine("\n------------------------------------");
        }
        Console.ResetColor();
    }
    public Szachownica()
    {   
        tura = 1;

        for (int i=0; i<8; i++)
        {
            plansza[1,i]=new Puste(); // na czas testów zmienione: plansza[1,i]=new Pionek(Kolor.biały);
            plansza[6,i]=new Pionek(Kolor.czarny);

            plansza[2,i]=new Puste();
            plansza[3,i]=new Puste();
            plansza[4,i]=new Puste();
            plansza[5,i]=new Puste();
        }

        plansza[4,3]=new Wieza(Kolor.biały); // czas testów, było: [0,0]
        plansza[0,0]=new Puste(); // usunąć po testach
        plansza[0,1]=new Skoczek(Kolor.biały);
        plansza[0,2]=new Goniec(Kolor.biały);
        plansza[2,3]=new Krol(Kolor.biały); // plansza[0,3]=new Krol(Kolor.biały);
        plansza[0,3]=new Puste(); // do usunięcia
        plansza[0,4]=new Hetman(Kolor.biały);
        plansza[0,5]=new Goniec(Kolor.biały);
        plansza[0,6]=new Skoczek(Kolor.biały);
        plansza[0,7]=new Wieza(Kolor.biały);

        plansza[7,0]=new Wieza(Kolor.czarny);
        plansza[7,1]=new Skoczek(Kolor.czarny);
        plansza[7,2]=new Goniec(Kolor.czarny);
        plansza[7,3]=new Krol(Kolor.czarny);
        plansza[7,4]=new Hetman(Kolor.czarny);
        plansza[7,5]=new Goniec(Kolor.czarny);
        plansza[7,6]=new Skoczek(Kolor.czarny);
        plansza[7,7]=new Wieza(Kolor.czarny);

        plansza[1,3]=new Skoczek(Kolor.czarny); //na czas testów sztucznie wstawiam pionek         
    }
}
// na koniec statystyki ile czasu na turę, czas rozgrywki, ile pkt kto stracił.
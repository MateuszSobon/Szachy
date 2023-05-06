class Szachownica
{
    Figura[,]  plansza = new Figura[8,8]; 

    int tura; //zlicza ile już tur zosrtało wykonanych

    public string kto_gra(int t)
    {
        if (t%2==0)
        {
            return "białe";
        }
        else
        {
            return "czarne";
        }
            
    }
    public void nowa_plansza()
    {
        tura++;
    }
    public void wypisz()
    {   
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"Tura: {tura}    Grają {kto_gra(tura)}");
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
        tura = 0;

        for (int i=0; i<8; i++)
        {
            plansza[1,i]=new Pionek(Kolor.biały);
            plansza[6,i]=new Pionek(Kolor.czarny);

            plansza[2,i]=new Puste();
            plansza[3,i]=new Puste();
            plansza[4,i]=new Puste();
            plansza[5,i]=new Puste();
        }

        plansza[0,0]=new Wieza(Kolor.biały);
        plansza[0,1]=new Skoczek(Kolor.biały);
        plansza[0,2]=new Goniec(Kolor.biały);
        plansza[0,3]=new Krol(Kolor.biały);
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
    }
}
// na koniec statystyki ile czasu na turę, czas rozgrywki, ile pkt kto stracił.
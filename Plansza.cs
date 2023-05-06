class Szachownica
{
    Figura[,]  plansza = new Figura[8,8]; 

    int tura; //zlicza ile już tur zosrtało wykonanych

    public void wypisz()
    {   
        Console.WriteLine("Tu będzie wyświetlony nagłówek");
        Console.WriteLine("---------------------------------");
        

        for(int i=0; i<plansza.GetLength(0); i++)
        
        {
            Console.Write("|");  
            for(int j=0; j<plansza.GetLength(1); j++)
            {
                Console.Write($"{plansza[i,j].nazwa}|");
                
            }
            Console.WriteLine("\n---------------------------------");
        }
    }
    public Szachownica()
    {   
        for (int i=0; i<8; i++)
        {
            plansza[1,i]=new Pionek(Kolor.czarny);
            plansza[6,i]=new Pionek(Kolor.biały);

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
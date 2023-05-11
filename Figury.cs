abstract class Figura
{
    public string nazwa 
    {
        get;
        set;
    }
    public string fnazwa
    {
        get;
        set;
    }
    private int zbić;
    public Kolor kolor //enum
    {
        get;
        set;
    } 
    protected int Zbić { get => zbić; set => zbić = value; }

    public Figura()
    {
        nazwa ="";
        fnazwa = "";
    }

    public abstract List<List<int>> ruch(int x, int y, Figura[,] Plansza);

}
class Pionek:Figura
{
    
    public Pionek(Kolor k)
    {
        nazwa = " P ";
        fnazwa = "pionek";
        kolor = k;
    }
    
    public override List<List<int>> ruch(int x, int y, Figura[,] Plansza)
    {
        List<List<int>> matrix = new List<List<int>>();

        if (Plansza[x,y].kolor==Kolor.biały) // ruch dla pionka białego
        {
            if(Plansza[x+1,y].nazwa=="   ")  // czy jest możliwy ruch do przodu
            {
                matrix.Add(new List<int>() {x+1, y, 0});     
            }
            if (x!=7 && y!= 7 && Plansza[x+1,y+1].kolor==Kolor.czarny && Plansza[x+1,y+1].nazwa!="   ")  // czy jest możliwy ruch ze zbiciem  w prawo
            {
                matrix.Add(new List<int>() {x+1, y+1, 1}); 
            }
            if (x!=7 && y!= 0 && Plansza[x+1,y-1].kolor==Kolor.czarny && Plansza[x+1,y-1].nazwa!="   ")  // czy jest możliwy ruch ze zbiciem  w lewo
            {
                matrix.Add(new List<int>() {x+1, y-1, 1}); 
            }
            return matrix;
        }
        else if (Plansza[x,y].kolor==Kolor.czarny) // ruch dla pionka czarnego
        {
            if(Plansza[x-1,y].nazwa=="   ")  // czy jest możliwy ruch do przodu
            {
                matrix.Add(new List<int>() {x-1, y, 0});     
            }
            if (x!=0 && y!=7 && Plansza[x-1,y+1].kolor==Kolor.biały && Plansza[x-1,y+1].nazwa!="   ")  // czy jest możliwy ruch ze zbiciem  w prawo
            {
                matrix.Add(new List<int>() {x-1, y+1, 1}); 
            }
            if (x!=0 && y!= 0 && Plansza[x-1,y-1].kolor==Kolor.biały && Plansza[x-1,y-1].nazwa!="   ")  // czy jest możliwy ruch ze zbiciem  w lewo
            {
                matrix.Add(new List<int>() {x-1, y-1, 1}); 
            }
            return matrix;
        }
        else 
        {
            Console.WriteLine("Błąd podczas wyboru pionka który ma wykonać ruch");
            matrix.Add(new List<int>() {x,y});
            return matrix;
        }
    }
}
class Wieza:Figura
{

    public Wieza(Kolor k)
    {
        nazwa = " W ";
        fnazwa = "wieża";
        kolor = k;
    }

    public override List<List<int>> ruch(int x, int y, Figura[,] Plansza)
    {
        List<List<int>> matrix = new List<List<int>>();
        return matrix;
    }
}
class Skoczek:Figura
{

    public Skoczek(Kolor k)
    {
        nazwa = " S ";
        fnazwa = "skoczek";
        kolor = k;
    }

    public override List<List<int>> ruch(int x, int y, Figura[,] Plansza)
    {
        List<List<int>> matrix = new List<List<int>>();
        return matrix;
    }
}
class Goniec:Figura
{

    public Goniec(Kolor k)
    {
        nazwa = " G ";
        fnazwa = "goniec";
        kolor = k;
    }

    public override List<List<int>> ruch(int x, int y, Figura[,] Plansza)
    {
        List<List<int>> matrix = new List<List<int>>();
        return matrix;
    }
}
class Krol:Figura
{

    public Krol(Kolor k)
    {
        nazwa = " K ";
        fnazwa = "król";
        kolor = k;
    }

    public override List<List<int>> ruch(int x, int y, Figura[,] Plansza)
    {
        List<List<int>> matrix = new List<List<int>>();
        return matrix;
    }
}
class Hetman:Figura
{

    public Hetman(Kolor k)
    {
        nazwa = " H ";
        fnazwa = "hetman";
        kolor = k;
    }
    public override List<List<int>> ruch(int x, int y, Figura[,] Plansza)
    {
        List<List<int>> matrix = new List<List<int>>();
        return matrix;
    }    
}
class Puste:Figura
{
    public Puste()
    {
        nazwa = "   ";
        fnazwa = "puste pole";

    }

    public override List<List<int>> ruch(int x, int y, Figura[,] Plansza)
    {
        List<List<int>> matrix = new List<List<int>>();
        return matrix;
    }
}
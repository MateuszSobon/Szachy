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
    
    public override List<List<int>> ruch(int x, int y, Figura[,] plansza)
    {
        List<List<int>> matrix = new List<List<int>>();

        if (plansza[x,y].kolor==Kolor.biały) // ruch dla pionka białego
        {
            if(plansza[x+1,y].nazwa=="   ")  // czy jest możliwy ruch do przodu
            {
                matrix.Add(new List<int>() {x+1, y, 0});     
            }
            if (x!=7 && y!= 7 && plansza[x+1,y+1].kolor==Kolor.czarny && plansza[x+1,y+1].nazwa!="   ")  // czy jest możliwy ruch ze zbiciem  w prawo
            {
                matrix.Add(new List<int>() {x+1, y+1, 1}); 
            }
            if (x!=7 && y!= 0 && plansza[x+1,y-1].kolor==Kolor.czarny && plansza[x+1,y-1].nazwa!="   ")  // czy jest możliwy ruch ze zbiciem  w lewo
            {
                matrix.Add(new List<int>() {x+1, y-1, 1}); 
            }
            return matrix;
        }
        else if (plansza[x,y].kolor==Kolor.czarny) // ruch dla pionka czarnego
        {
            if(plansza[x-1,y].nazwa=="   ")  // czy jest możliwy ruch do przodu
            {
                matrix.Add(new List<int>() {x-1, y, 0});     
            }
            if (x!=0 && y!=7 && plansza[x-1,y+1].kolor==Kolor.biały && plansza[x-1,y+1].nazwa!="   ")  // czy jest możliwy ruch ze zbiciem  w prawo
            {
                matrix.Add(new List<int>() {x-1, y+1, 1}); 
            }
            if (x!=0 && y!= 0 && plansza[x-1,y-1].kolor==Kolor.biały && plansza[x-1,y-1].nazwa!="   ")  // czy jest możliwy ruch ze zbiciem  w lewo
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

    public override List<List<int>> ruch(int x, int y, Figura[,] plansza)
    {
        List<List<int>> matrix = new List<List<int>>();
        if(plansza[x,y].kolor==Kolor.biały)
        {   
            for(int i=x; i>=0; i--) //ruch w dół w pion od położenia pionka w chwili obecnej
            {
                if (plansza[i,y].nazwa=="   ")
                {
                    matrix.Add(new List<int>() {i,y,0});
                }
                else if(plansza[i,y].kolor==Kolor.czarny) 
                {
                    matrix.Add(new List<int>() {i,y,1});
                    break;
                }
            }
            for(int i=x; i<8; i++) //ruch w górę w pionie od położenia pionka w chwili obecnej
            {
                if (plansza[i,y].nazwa=="   ")
                {
                    matrix.Add(new List<int>() {i,y,0});
                }
                else if(plansza[i,y].kolor==Kolor.czarny) 
                {
                    matrix.Add(new List<int>() {i,y,1});
                    break;
                }
            }
            for(int i=y; i>=0; i--) //ruch w lewo w poziomie od położenia pionka w chwili obecnej
            {
                if (plansza[x,i].nazwa=="   ")
                {
                    matrix.Add(new List<int>() {x,i,0});
                }
                else if(plansza[x,i].kolor==Kolor.czarny) 
                {
                    matrix.Add(new List<int>() {x,i,1});
                    break;
                }
            }
            for(int i=y; i<8; i++) //ruch w prawo w poziomie od położenia pionka w chwili obecnej
            {
                if (plansza[x,i].nazwa=="   ")
                {
                    matrix.Add(new List<int>() {x,i,0});
                }
                else if(plansza[x,i].kolor==Kolor.czarny) 
                {
                    matrix.Add(new List<int>() {x,i,1});
                    break;
                }
            }
            return matrix;
        }
        else if(plansza[x,y].kolor==Kolor.czarny)
        {
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
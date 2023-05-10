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
    public Kolor kolor
    {
        get;
        set;
    } //enum!
    protected int Zbić { get => zbić; set => zbić = value; }

    public Figura()
    {
        nazwa ="";
        fnazwa = "";
    }

    public abstract int[,] ruch(int x, int y, Figura[,] plansza)
    {
        
    } 
}
class Pionek:Figura
{
    
    public Pionek(Kolor k)
    {
        nazwa = " P ";
        fnazwa = "pionek";
        kolor = k;
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
}
class Skoczek:Figura
{

    public Skoczek(Kolor k)
    {
        nazwa = " S ";
        fnazwa = "skoczek";
        kolor = k;
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
}
class Krol:Figura
{

    public Krol(Kolor k)
    {
        nazwa = " K ";
        fnazwa = "król";
        kolor = k;
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
}
class Puste:Figura
{
    public Puste()
    {
        nazwa = "   ";
        fnazwa = "puste pole";

    }
}
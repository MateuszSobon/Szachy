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
                for(int i=x; i>=0; i--) //ruch w dół w pion od położenia pionka w chwili obecnej
            {
                if (plansza[i,y].nazwa=="   ")
                {
                    matrix.Add(new List<int>() {i,y,0});
                }
                else if(plansza[i,y].kolor==Kolor.biały) 
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
                else if(plansza[i,y].kolor==Kolor.biały) 
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
                else if(plansza[x,i].kolor==Kolor.biały) 
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
                else if(plansza[x,i].kolor==Kolor.biały) 
                {
                    matrix.Add(new List<int>() {x,i,1});
                    break;
                }
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
class Skoczek:Figura
{

    public Skoczek(Kolor k)
    {
        nazwa = " S ";
        fnazwa = "skoczek";
        kolor = k;
    }

    public override List<List<int>> ruch(int x, int y, Figura[,] plansza)
    {
        List<List<int>> matrix = new List<List<int>>();
        if (plansza[x,y].kolor==Kolor.biały)
        {
            if(x+2<8)
            {
                if(y+1<8 && plansza[x+2,y+1].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x+2,y+1,0});
                }

                if(y-1>=0 && plansza[x+2,y-1].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x+2, y-1, 0});
                }

                if(y+1<8 && plansza[x+2,y+1].kolor==Kolor.czarny)
                {
                    matrix.Add(new List<int> () {x+2,y+1,1});
                }

                if(y-1>=0 && plansza[x+2,y-1].kolor==Kolor.czarny)
                {
                    matrix.Add(new List<int> () {x+2, y-1, 1});
                }
            }
            if(x+1<8)
            {
                if(y+2<8 && plansza[x+1,y+2].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x+1,y+2,0});
                }

                if(y-2>=0 && plansza[x+1,y-2].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x+1, y-2, 0});
                }
                if(y+2<8 && plansza[x+1,y+2].kolor==Kolor.czarny)
                {
                    matrix.Add(new List<int> () {x+1,y+2,1});
                }

                if(y-2>=0 && plansza[x+1,y-2].kolor==Kolor.czarny)
                {
                    matrix.Add(new List<int> () {x+1, y-2, 1});
                }
            }
            if(x-2>=0) // dodaje 3 pare 
            {
                if(y+1<8 && plansza[x-2,y+1].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x-2,y+1,0});
                }

                if(y-1>=0 && plansza[x-2,y-1].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x-2, y-1, 0});
                }
                if(y+1<8 && plansza[x-2,y+1].kolor==Kolor.czarny)
                {
                    matrix.Add(new List<int> () {x-2,y+1,1});
                }

                if(y-1>=0 && plansza[x-2,y-1].kolor==Kolor.czarny)
                {
                    matrix.Add(new List<int> () {x-2, y-1, 1});
                }
            }
            if(x-1>=0) // dodaje 4 parę 
            {
                if(y+2<8 && plansza[x-1,y+2].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x-1,y+2,0});
                }

                if(y-2>=0 && plansza[x-1,y-2].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x-1, y-2, 0});
                }
                if(y+2<8 && plansza[x-1,y+2].kolor==Kolor.czarny)
                {
                    matrix.Add(new List<int> () {x-1,y+2,1});
                }

                if(y-2>=0 && plansza[x-1,y-2].kolor==Kolor.czarny)
                {
                    matrix.Add(new List<int> () {x-1, y-2, 1});
                }
            }
            return matrix;
        }
        else if(plansza[x,y].kolor==Kolor.czarny) //sprawdzam pozycje dla czarnych 
        {
            if(x+2<8)
            {
                if(y+1<8 && plansza[x+2,y+1].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x+2,y+1,0});
                }

                if(y-1>=0 && plansza[x+2,y-1].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x+2, y-1, 0});
                }

                if(y+1<8 && plansza[x+2,y+1].kolor==Kolor.biały)
                {
                    matrix.Add(new List<int> () {x+2,y+1,1});
                }

                if(y-1>=0 && plansza[x+2,y-1].kolor==Kolor.biały)
                {
                    matrix.Add(new List<int> () {x+2, y-1, 1});
                }
            }
            if(x+1<8)
            {
                if(y+2<8 && plansza[x+1,y+2].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x+1,y+2,0});
                }

                if(y-2>=0 && plansza[x+1,y-2].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x+1, y-2, 0});
                }
                if(y+2<8 && plansza[x+1,y+2].kolor==Kolor.biały)
                {
                    matrix.Add(new List<int> () {x+1,y+2,1});
                }

                if(y-2>=0 && plansza[x+1,y-2].kolor==Kolor.biały)
                {
                    matrix.Add(new List<int> () {x+1, y-2, 1});
                }
            }
            if(x-2>=0) // dodaje 3 pare 
            {
                if(y+1<8 && plansza[x-2,y+1].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x-2,y+1,0});
                }

                if(y-1>=0 && plansza[x-2,y-1].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x-2, y-1, 0});
                }
                if(y+1<8 && plansza[x-2,y+1].kolor==Kolor.biały)
                {
                    matrix.Add(new List<int> () {x-2,y+1,1});
                }

                if(y-1>=0 && plansza[x-2,y-1].kolor==Kolor.biały)
                {
                    matrix.Add(new List<int> () {x-2, y-1, 1});
                }
            }
            if(x-1>=0) // dodaje 4 parę 
            {
                if(y+2<8 && plansza[x-1,y+2].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x-1,y+2,0});
                }

                if(y-2>=0 && plansza[x-1,y-2].nazwa=="   ")
                {
                    matrix.Add(new List<int> () {x-1, y-2, 0});
                }
                if(y+2<8 && plansza[x-1,y+2].kolor==Kolor.biały)
                {
                    matrix.Add(new List<int> () {x-1,y+2,1});
                }

                if(y-2>=0 && plansza[x-1,y-2].kolor==Kolor.biały)
                {
                    matrix.Add(new List<int> () {x-1, y-2, 1});
                }
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
class Goniec:Figura
{

    public Goniec(Kolor k)
    {
        nazwa = " G ";
        fnazwa = "goniec";
        kolor = k;
    }

    public override List<List<int>> ruch(int x, int y, Figura[,] plansza)
    {
        List<List<int>> matrix = new List<List<int>>();
        if(plansza[x,y].kolor==Kolor.biały)
        {
            if(x>0 && y>0) //wykluczam skrajne położenia 
            {   
                int i=x-1;
                for(int j=y-1; j>=0 && i>=0; j--,i-- )
                {
                    if(plansza[i,j].nazwa=="   ") //jeżeli jest puste miejsce to dodaj ruch do listy
                    {
                        matrix.Add(new List<int> () {i,j,0});
                    }
                    else if (plansza[i,j].kolor==Kolor.czarny) //jeżeli jest przeciwnik na polu to dodaj to pole i wyjdz z pętli
                    {
                        matrix.Add(new List<int> () {i,j,1});
                        break;
                    }
                    else if (plansza[i,j].kolor==plansza[x,y].kolor) // wyjdz z pętli jeżeli masz pionka ze swojego koloru
                    {
                        break;
                    }
                }
            }
            if(x>0 && y<7)
            {   
                int i=x-1;
                for(int j=y+1; j<8 && i>=0; j++,i-- )
                {
                    if(plansza[i,j].nazwa=="   ") //jeżeli jest puste miejsce to dodaj ruch do listy
                    {
                        matrix.Add(new List<int> () {i,j,0});
                    }
                    else if (plansza[i,j].kolor==Kolor.czarny) //jeżeli jest przeciwnik na polu to dodaj to pole i wyjdz z pętli
                    {
                        matrix.Add(new List<int> () {i,j,1});
                        break;
                    }
                    else if (plansza[i,j].kolor==plansza[x,y].kolor) // wyjdz z pętli jeżeli masz pionka ze swojego koloru
                    {
                        break;
                    }
                }
            }
            if(x<7 && y<7)
            {
                int i=x+1;
                for(int j=y+1; j<8 && i<8 ; j++, i++)
                {   
                    if(plansza[i,j].nazwa=="   ") //jeżeli jest puste miejsce to dodaj ruch do listy
                    {
                        matrix.Add(new List<int> () {i,j,0});
                    }
                    else if (plansza[i,j].kolor==Kolor.czarny) //jeżeli jest przeciwnik na polu to dodaj to pole i wyjdz z pętli
                    {
                        matrix.Add(new List<int> () {i,j,1});
                        break;
                    }
                    else if (plansza[i,j].kolor==plansza[x,y].kolor) // wyjdz z pętli jeżeli masz pionka ze swojego koloru
                    {
                        break;
                    }
                }
            }
            if(x<7 && y>0)
            {
                int i=x+1;
                for(int j=y-1; j>=0 && i<8; j--,i++ )
                {
                    if(plansza[i,j].nazwa=="   ") //jeżeli jest puste miejsce to dodaj ruch do listy
                    {
                        matrix.Add(new List<int> () {i,j,0});
                    }
                    else if (plansza[i,j].kolor==Kolor.czarny) //jeżeli jest przeciwnik na polu to dodaj to pole i wyjdz z pętli
                    {
                        matrix.Add(new List<int> () {i,j,1});
                        break;
                    }
                    else if (plansza[i,j].kolor==plansza[x,y].kolor) // wyjdz z pętli jeżeli masz pionka ze swojego koloru
                    {
                        break;
                    }
                }
            } 
        }
        if(plansza[x,y].kolor==Kolor.czarny)
        {
            if(x>0 && y>0) //wykluczam skrajne położenia 
            {   
                int i=x-1;
                for(int j=y-1; j>=0 && i>=0; j--,i-- )
                {
                    if(plansza[i,j].nazwa=="   ") //jeżeli jest puste miejsce to dodaj ruch do listy
                    {
                        matrix.Add(new List<int> () {i,j,0});
                    }
                    else if (plansza[i,j].kolor==Kolor.biały) //jeżeli jest przeciwnik na polu to dodaj to pole i wyjdz z pętli
                    {
                        matrix.Add(new List<int> () {i,j,1});
                        break;
                    }
                    else if (plansza[i,j].kolor==plansza[x,y].kolor) // wyjdz z pętli jeżeli masz pionka ze swojego koloru
                    {
                        break;
                    }
                }
            }
            if(x>0 && y<7)
            {   
                int i=x-1;
                for(int j=y+1; j<8 && i>=0; j++,i-- )
                {
                    if(plansza[i,j].nazwa=="   ") //jeżeli jest puste miejsce to dodaj ruch do listy
                    {
                        matrix.Add(new List<int> () {i,j,0});
                    }
                    else if (plansza[i,j].kolor==Kolor.biały) //jeżeli jest przeciwnik na polu to dodaj to pole i wyjdz z pętli
                    {
                        matrix.Add(new List<int> () {i,j,1});
                        break;
                    }
                    else if (plansza[i,j].kolor==plansza[x,y].kolor) // wyjdz z pętli jeżeli masz pionka ze swojego koloru
                    {
                        break;
                    }
                }
            }
            if(x<7 && y<7)
            {
                int i=x+1;
                for(int j=y+1; j<8 && i<8 ; j++, i++)
                {   
                    if(plansza[i,j].nazwa=="   ") //jeżeli jest puste miejsce to dodaj ruch do listy
                    {
                        matrix.Add(new List<int> () {i,j,0});
                    }
                    else if (plansza[i,j].kolor==Kolor.biały) //jeżeli jest przeciwnik na polu to dodaj to pole i wyjdz z pętli
                    {
                        matrix.Add(new List<int> () {i,j,1});
                        break;
                    }
                    else if (plansza[i,j].kolor==plansza[x,y].kolor) // wyjdz z pętli jeżeli masz pionka ze swojego koloru
                    {
                        break;
                    }
                }
            }
            if(x<7 && y>0)
            {
                int i=x+1;
                for(int j=y-1; j>=0 && i<8; j--,i++ )
                {
                    if(plansza[i,j].nazwa=="   ") //jeżeli jest puste miejsce to dodaj ruch do listy
                    {
                        matrix.Add(new List<int> () {i,j,0});
                    }
                    else if (plansza[i,j].kolor==Kolor.biały) //jeżeli jest przeciwnik na polu to dodaj to pole i wyjdz z pętli
                    {
                        matrix.Add(new List<int> () {i,j,1});
                        break;
                    }
                    else if (plansza[i,j].kolor==plansza[x,y].kolor) // wyjdz z pętli jeżeli masz pionka ze swojego koloru
                    {
                        break;
                    }
                }
            }
        }

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
        if(Plansza[x,y].kolor==Kolor.biały)
        {
            if(x>0)
            {

            }
        }
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
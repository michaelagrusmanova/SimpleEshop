using System.Collections.Generic;

namespace E_shop
{
    internal class Sklad
    {
        List<PolozkaZbozi> _polozky;
        List<Uzivatel> _uzivatele;

    public Sklad(List<PolozkaZbozi> zbozi, List<Uzivatel> uzivatele)
    {
            _polozky = new List<PolozkaZbozi>();
            _uzivatele = new List<Uzivatel>();
            _polozky = zbozi;
            _uzivatele = uzivatele;
    }

       public void pridejDoKosiku(Uzivatel u, PolozkaZbozi p)
        {
            foreach(var po in _polozky)
            {
                if(po == p)
                {
                    
                }
            }
        }


    /*public PolozkaZbozi getPolozkaNaSklade(string jmeno)
    {
        for (int i = 0; i < _polozky.Capacity; i++)
        {
            if (_polozky[i] == jmeno)
            {
                return _polozky[i];
            }
        }
    }*/
}
}
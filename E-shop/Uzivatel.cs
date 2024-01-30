using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace E_shop
{
    public class Uzivatel
    {
        string _jmeno;
        string _email;
        List<PolozkaZbozi> _pz;
        List<NakupniKosik> _nk;

        public Uzivatel(string jmeno, string email)
        {
            _jmeno = jmeno;
            _email = email;
            _pz = new List<PolozkaZbozi>();
            _nk = new List<NakupniKosik>();
        }

        public double getcelkemCena()
        {
            double celkem = 0;
            foreach(var a in _nk)
            {
               celkem += a.getCena();
            }
            return celkem;
        }


        public void pridejPolozkuZbozi(PolozkaZbozi polozka)
        {
            Boolean nalezeno = false;
            _pz.Add(polozka);
            polozka.snizHodnotuNaSkladu();
            //nk.zvysPocetVKosiku(polozka);
            foreach(var o in _nk)
            {
                if(polozka.getNazev() == o.getNazev())
                {
                    o.zvysPocetVKosiku();
                    nalezeno = true;
                } 
            }
            if (nalezeno == false)
            {
                _nk.Add(new NakupniKosik(polozka));
            }
        }

        public void odeberPolozkuZbozi(PolozkaZbozi polozka)
        {
            _pz.Remove(polozka);
            polozka.zvysHodnotuNaSkladu();
            foreach(var o in _nk)
            {
                if(polozka.getNazev() == o.getNazev())
                {
                    o.snizPocetVKosiku();
                }
            }
        }

        public List<PolozkaZbozi> vratKosik()
        {
            return _pz;
        }

        public List<NakupniKosik> vratKO()
        {
            return _nk;
        }

        public override string ToString()
        {
            return (_jmeno + "; " + _email);
        }


        public string getVypisKosiku()
        {
           StringBuilder sb = new StringBuilder();
            /*
            foreach(var p in _pz)
            {
                sb.Append(p.getNazev() + " " + p.getPocetUzivatel());
                sb.AppendLine();
            }
            return sb.ToString();*/
            foreach(var p in _nk)
            {
                sb.Append(p.getVypis());
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
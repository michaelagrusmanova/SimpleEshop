using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_shop
{
    public class NakupniKosik
    {
        PolozkaZbozi po;
        int pocetKusuVKosiku;

        public NakupniKosik(PolozkaZbozi pol)
        {
            po = pol;
            pocetKusuVKosiku = 1;
        }

        public void zvysPocetVKosiku()
        {
            pocetKusuVKosiku++;
        }

        public void snizPocetVKosiku()
        {
            if (pocetKusuVKosiku <= 0)
            {
                return;
            } else {
                pocetKusuVKosiku--;
             }
        }

        public string getNazev()
        {
            return po.getNazev();
        }

        public int getPocetVKosiku()
        {
            return pocetKusuVKosiku;
        }

        public string getVypis()
        {
            return (po.getNazev() + "; " + pocetKusuVKosiku);
        }

        public PolozkaZbozi getPolozkaZbozi()
        {
            return po;
        }

        public double getCena()
        {
            return (po.getCena() * pocetKusuVKosiku);
        }

        public override string ToString()
        {
            return (po.getNazev() + "; " + pocetKusuVKosiku + "; cena: " + pocetKusuVKosiku*po.getCena());
        }
    }


}

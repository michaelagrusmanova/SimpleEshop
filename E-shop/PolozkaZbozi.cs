using System;
using System.Collections.Generic;

namespace E_shop
{
    public class PolozkaZbozi
    {
        string _nazev { get; set; }
        double _cena { get; set; }
        int _pocetNaSklade { get; set; }
        int _pocetUzivatel { get; set; }
    

        public PolozkaZbozi(string nazev, double cena, int pocetSklad)
        {
            _nazev = nazev;
            _cena = cena;
            _pocetNaSklade = pocetSklad;
            _pocetUzivatel = 0;
        }


        public double getCena()
        {
            return _cena;
        }

        public string getNazev()
        {
            return _nazev;
        }

        internal void setPocetUzivatel(int pocet)
        {
            _pocetUzivatel = pocet;
        }

        public int getPocetNaSklade()
        {
            return _pocetNaSklade;
        }

        public int getPocetUzivatel()
        {
            return _pocetUzivatel;
        }

        public override string ToString()
        {
            return (_nazev + "; " + _cena + "; " + _pocetNaSklade);
        }

        public void snizHodnotuNaSkladu()
        {
            _pocetNaSklade--;
        }

        public void zvysHodnotuNaSkladu()
        {
            _pocetNaSklade++;
        }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace E_shop
{
    public partial class Form1 : Form
    {
        BindingList<PolozkaZbozi> pz = new BindingList<PolozkaZbozi>();
        BindingList<Uzivatel> uziv = new BindingList<Uzivatel>();
        List<int> puvodniPocet = new List<int>();

        public Form1()
        {
            InitializeComponent();
            #region pridavaniPolozekZbozi
            pz.Add(new PolozkaZbozi("banán", 7.20, 3));
            pz.Add(new PolozkaZbozi("křen", 6.50, 30));
            pz.Add(new PolozkaZbozi("rohlík", 2.50, 200));
            pz.Add(new PolozkaZbozi("chléb", 20.90, 60));
            pz.Add(new PolozkaZbozi("sýr", 39.90, 20));
            pz.Add(new PolozkaZbozi("šunka", 34.90, 32));
            pz.Add(new PolozkaZbozi("šťáva", 35.90, 46));
            pz.Add(new PolozkaZbozi("jablko", 5.50, 69));
            pz.Add(new PolozkaZbozi("mrkev", 6.50, 38));
            pz.Add(new PolozkaZbozi("sušenka", 9.90, 88));
            pz.Add(new PolozkaZbozi("hořčice", 28.90, 26));
            pz.Add(new PolozkaZbozi("čaj", 17.90, 123));
            pz.Add(new PolozkaZbozi("káva", 46.90, 54));
            pz.Add(new PolozkaZbozi("mléko", 19.90, 71));
            pz.Add(new PolozkaZbozi("máslo", 39.90, 29));
            pz.Add(new PolozkaZbozi("jogurt", 14.90, 59));
            listBox1.Refresh();
            listBox1.DataSource = pz;
            #endregion
            #region puvodniPoctyZboziNaSklade
            for (int i=0; i<pz.Count();i++)
            {
                puvodniPocet.Add(pz[i].getPocetNaSklade());
            }
            #endregion
            #region pridavaniUzivatelu
            uziv.Add(new Uzivatel("Andrea Nováková", "andy.novak@seznam.cz"));
            uziv.Add(new Uzivatel("Tomáš Brzobohatý", "tommiB@gmail.com"));
            uziv.Add(new Uzivatel("Klára Bystrá", "bystrouska@volny.cz"));
            uziv.Add(new Uzivatel("Filip Lhoták", "lhotak99@seznam.cz"));
            uziv.Add(new Uzivatel("David Ouhel", "david.ouhel@seznam.cz"));
            uziv.Add(new Uzivatel("Simona Panklová", "simpan@gmail.com"));
            uziv.Add(new Uzivatel("Jitka Stará", "starJit@gmail.com"));
            uziv.Add(new Uzivatel("Petr Plachý", "plachon98@seznam.cz"));
            listBox2.Refresh();
            listBox2.DataSource = uziv;
            #endregion
        }

        /*
         * Přidání položky do košíku, odebrání ze skladu
         */
        private void button1_Click(object sender, EventArgs e)
        {
            PolozkaZbozi polozka = null;
            for (int i = 0; i < pz.Count(); i++)
            {
                if (listBox1.GetSelected(i))
                {
                    polozka = pz[i];
                }
            }
            for (int i = 0; i < uziv.Count(); i++)
            {
                if (listBox2.GetSelected(i) && polozka.getPocetNaSklade() > 0)
                {
                    uziv[i].pridejPolozkuZbozi(polozka);
                }
            }
            zaznamDoKosiku();
            aktualizujSklad();
        }

        /*
         * Odebrání položky z košíku, přidání zpět do skladu
         */
        private void button2_Click(object sender, EventArgs e)
        {
            PolozkaZbozi polozka = null;
            int index = 0;
            for (int i = 0; i < pz.Count(); i++)
            {
                if (listBox1.GetSelected(i))
                {
                    polozka = pz[i];
                    index = i;
                }
            }
            for (int i = 0; i < uziv.Count(); i++)
            {
                if (listBox2.GetSelected(i) && polozka.getPocetNaSklade() < puvodniPocet[index])
                {
                    uziv[i].odeberPolozkuZbozi(polozka);
                }
            }
            zaznamDoKosiku();
            aktualizujSklad();
        }

        /*
         * Vytvoření nového zákazníka
         */
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(uziv);
            f2.ShowDialog();
        }

        /*
         * Vypočtení celkové ceny v košíku zákazníka
         */
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < uziv.Count(); i++)
            {
                if (listBox2.GetSelected(i))
                {
                    label1.Text = uziv[i].getcelkemCena() + " Kč";
                }
            }
        }

        /*
        * Aktualizace košíku a skladu při výběru uživatele
        */
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            zaznamDoKosiku();
            aktualizujSklad();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        /*
         * Aktualizační metody
         */
        private void zaznamDoKosiku()
        {
            BindingList<NakupniKosik> nk = new BindingList<NakupniKosik>();
            for (int i = 0; i < uziv.Count(); i++)
            {
                if (listBox2.GetSelected(i))
                {
                   nk = new BindingList<NakupniKosik>(uziv[i].vratKO());
                    listBox3.Refresh();

                }

            }
            listBox3.DataSource = nk;
        }

        private void aktualizujSklad()
        {
            BindingList<PolozkaZbozi> pzu = new BindingList<PolozkaZbozi>();
            pzu = new BindingList<PolozkaZbozi>(pz);
            listBox1.Refresh();
            listBox1.DataSource = pzu;
        }

    }
}

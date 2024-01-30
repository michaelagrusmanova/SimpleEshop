using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_shop
{
    public partial class Form2 : Form
    {
        BindingList<Uzivatel> uzi;
        public Form2(BindingList<Uzivatel> uzivatele)
        {
            InitializeComponent();
            uzi = uzivatele;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jmeno = textBox1.Text;
            string email = textBox2.Text;
            Uzivatel uzivatel = new Uzivatel(jmeno, email);
            uzi.Add(uzivatel);
            this.Hide();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

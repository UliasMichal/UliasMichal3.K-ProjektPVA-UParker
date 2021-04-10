using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UParker
{
    public partial class Form6 : Form
    {
        //Form slouží pro vynucenou změnu hesla

        User userNucenZmenitHeslo;
        bool chceDoAdminFormu;
        DateTime loginCas;

        public Form6(User userFormu, bool chceAdminForm, DateTime casLoginu)
        {
            userNucenZmenitHeslo = userFormu;
            chceDoAdminFormu = chceAdminForm;
            loginCas = casLoginu;
            InitializeComponent();
        }

        private void loginB_Click(object sender, EventArgs e)
        {
            //změň heslo, zavři toto okno a dovol uživateli pokračovat na main-účet
            if (HesloJednaTB.Text == HesloDvaTB.Text)
            {
                if (HesloJednaTB.Text != "")
                {
                    if (HesloJednaTB.Text.Length >= 5)
                    {
                        string sifrovaneHeslo = SifrovaniHesla.Sifruj(userNucenZmenitHeslo.Username, HesloJednaTB.Text);
                        userNucenZmenitHeslo.MaVynucenouZmenuHesla = false;
                        if (sifrovaneHeslo != userNucenZmenitHeslo.Heslo)
                        {
                            userNucenZmenitHeslo.Heslo = sifrovaneHeslo;
                            if (chceDoAdminFormu)
                            {
                                //pusť do admin-formu
                                MessageBox.Show("Heslo úspěšně změněno - pouštíme Vás do admin-formu", "SUCCESS");
                                Form4 adminForm = new Form4(userNucenZmenitHeslo, loginCas);
                                adminForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                //pusť do user-formu
                                MessageBox.Show("Heslo úspěšně změněno - pouštíme Vás do user-formu", "SUCCESS");
                                Form2 userForm = new Form2(userNucenZmenitHeslo, loginCas);
                                userForm.Show();
                                this.Hide();
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Nové heslo nemůže být stejné jako to staré!", "ERROR");
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Heslo nesmí být kratší než 5 znaků!", "ERROR");
                    }
                }
                else 
                {
                    MessageBox.Show("Hesla nesmí být prázdná!", "ERROR");
                }
            }
            else 
            {
                MessageBox.Show("Hesla se neshodují!", "ERROR");
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Byla Vám vynucena změna hesla adminem", "Změňte si heslo!");
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Vracíme Vás zpět na Login-screen - toto se nepočítá jako validní login", "Nezměnili jste si heslo!");
            Form1 login = new Form1();
            login.Show();
        }
    }
}

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
    public partial class Form5 : Form
    {
        //Form slouží pro změnu hesla

        User userChceZmenitHeslo;
        bool chceDoAdminFormu;
        DateTime loginCas;

        public Form5(User userFormu, bool chceAdminForm, DateTime casLoginu)
        {
            userChceZmenitHeslo = userFormu;
            chceDoAdminFormu = chceAdminForm;
            loginCas = casLoginu;
            InitializeComponent();
        }


        private void PotvrditB_Click(object sender, EventArgs e)
        {
            //změň heslo, zavři toto okno a dovol uživateli pokračovat na main-účet
            if (SifrovaniHesla.Sifruj(userChceZmenitHeslo.Username, AktualniHesloTB.Text) == userChceZmenitHeslo.Heslo)
            {
                if (NoveHesloJednaTB.Text == NoveHesloDvaTB.Text)
                {
                    if (NoveHesloJednaTB.Text != "")
                    {
                        if (NoveHesloJednaTB.Text.Length >= 5)
                        {
                            string sifrovaneHeslo = SifrovaniHesla.Sifruj(userChceZmenitHeslo.Username, NoveHesloJednaTB.Text);
                            if (sifrovaneHeslo != userChceZmenitHeslo.Heslo)
                            {
                                userChceZmenitHeslo.Heslo = sifrovaneHeslo;
                                if (chceDoAdminFormu)
                                {
                                    //pusť zpět do admin-formu
                                    MessageBox.Show("Heslo úspěšně změněno - pouštíme Vás do admin-formu", "SUCCESS");
                                    Form4 adminForm = new Form4(userChceZmenitHeslo, loginCas);
                                    adminForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    //pusť zpět do user-formu
                                    MessageBox.Show("Heslo úspěšně změněno - pouštíme Vás do user-formu", "SUCCESS");
                                    Form2 userForm = new Form2(userChceZmenitHeslo, loginCas);
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
            else
            {
                MessageBox.Show("Aktuální heslo se neshoduje s vaším aktuálním heslem!", "ERROR");
            }
        }

        private void BackB_Click(object sender, EventArgs e)
        {
            if (chceDoAdminFormu) 
            {
                Form4 minulyForm = new Form4(userChceZmenitHeslo, loginCas);
                minulyForm.Show();
                this.Hide();
            }
            else 
            {
                Form2 minulyForm = new Form2(userChceZmenitHeslo, loginCas);
                minulyForm.Show();
                this.Hide();
            }
        }
    }
}

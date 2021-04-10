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
    public partial class Form1 : Form
    {
        //Form slouží pro login do systému admina či usera

        public Form1()
        {
            InitializeComponent();
        }

        private void LoginB_Click(object sender, EventArgs e)
        {
            string userID = UserIDTB.Text;
            string username = UsernameTB.Text;
            if(UserIDTB.Text.Length == 0 || UsernameTB.Text.Length == 0 || HesloTB.Text.Length == 0) 
            {
                MessageBox.Show("Délka všech parametrů musí být delší než 0","ERROR");
                return;
            }
            string heslo = SifrovaniHesla.Sifruj(username, HesloTB.Text);

            int indexUzivatele = NajdiUzivatele(userID, username, heslo, adminCheckB.Checked);

            if (indexUzivatele == -1) 
            {
                //Zamítne přístup
                if (adminCheckB.Checked)
                {
                    MessageBox.Show("Login-failed - buď: 1. špatné username, 2. špatné heslo, 3. špatné ID, či 4. váš účet nemá admin práva", "ERROR");
                }
                else
                {
                    MessageBox.Show("Login-failed - buď: 1. špatné username, 2. špatné heslo, či 3. špatné ID", "ERROR");
                }
            }
            else
            {
                //Přihlásí do:
                User loginUser = PromenneProVsechnyForms.UsersList[indexUzivatele];

                if (adminCheckB.Checked)
                {
                    if (loginUser.MaVynucenouZmenuHesla)
                    {
                        //před-přihlášením mu hodí pop-up na změnu hesla s parametrem admin=true
                        Form6 zmenaHesla = new Form6(loginUser, true, DateTime.Now);
                        zmenaHesla.Show();
                    }
                    else
                    {
                        //přihlásí do admin-konzole
                        Form4 adminForm = new Form4(loginUser, DateTime.Now);
                        adminForm.Show();
                    }
                }
                else
                {
                    if (loginUser.MaVynucenouZmenuHesla)
                    {
                        //před-přihlášením mu hodí pop-up na změnu hesla s parametrem admin=false
                        Form6 zmenaHesla = new Form6(loginUser, false, DateTime.Now);
                        zmenaHesla.Show();
                    }
                    else
                    {
                        //přihlásí do user-konzole
                        Form2 userForm = new Form2(loginUser, DateTime.Now);
                        userForm.Show();
                    }
                }

                this.Hide();
            }
        }

        private int NajdiUzivatele(string userID, string username, string hesloZasifrovano, bool autorizaceCheck) 
        {
            for (int i = 0; i < PromenneProVsechnyForms.UsersList.Count; i++) 
            {
                if (PromenneProVsechnyForms.UsersList[i].UserID == userID && PromenneProVsechnyForms.UsersList[i].Username == username && PromenneProVsechnyForms.UsersList[i].Heslo == hesloZasifrovano) 
                {
                    if (autorizaceCheck)
                    {
                        if (PromenneProVsechnyForms.UsersList[i].JeAdmin)
                        {
                            return i;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Pro ukončení programu zvolte soubor, do kterého uložíte databázi", "Ukončujeme program");
            UlozDoSouboru.UlozVseDoTxtSouboru();
            Environment.Exit(0);
        }
    }
}

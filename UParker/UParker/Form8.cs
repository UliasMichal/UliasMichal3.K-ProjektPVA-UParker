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
    public partial class Form8 : Form
    {
        //Form slouží pro správu všech userů

        string idAdmina;

        public Form8(string idAdminaSpoustejiciForm)
        {
            idAdmina = idAdminaSpoustejiciForm;
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            VynuceniZmenyHeslaCheckB.Checked = true;
            ReloadListBoxUseru();
        }

        private void ReloadUserVSystemuB_Click(object sender, EventArgs e)
        {
            ReloadListBoxUseru();
        }

        private void OdstranitUserB_Click(object sender, EventArgs e)
        {
            if (GeneratorID.ExistujeID(RemoveUserByIDTB.Text))
            {
                if(RemoveUserByIDTB.Text == idAdmina) 
                {
                    MessageBox.Show("Nemůžete smazat svůj účet - požádejte jiného admina o jeho smazání", "ERROR");
                    return;
                }
                foreach (User u in PromenneProVsechnyForms.UsersList)
                {
                    if (u.UserID == RemoveUserByIDTB.Text)
                    {
                        if (u.KrestniJmeno == "Odstraneny" && u.Prijmeni == "Uzivatel") 
                        {
                            MessageBox.Show("Nelze odstranit již odstraněného uživatele", "ERROR");
                            return;
                        }
                        u.OdstranitZeSystemu();
                        MessageBox.Show("Uživatel úspěšně odstraněn ze systému - nyní je veden pod názvem: " + u.Username, "SUCCESS");
                        ReloadListBoxUseru();
                        break;
                    }
                }
            }
            else 
            {
                MessageBox.Show("User s tímto IDem neexistuje - zkuste znovu", "ERROR");
            }
        }

        private void AddUserB_Click(object sender, EventArgs e)
        {
            if(UsernameTB.Text.Length == 0 || KrestniTB.Text.Length == 0 || PrijmeniTB.Text.Length == 0 || HesloTB.Text.Length < 5) 
            {
                MessageBox.Show("Jména a username nesmí být prázdné + heslo musí být delší než 5 znaků","ERROR");
                return;
            }

            if (!KontrolaTextVstupu.KontrolaUsernameANazvuAut(UsernameTB.Text))
            {
                MessageBox.Show("Prosím používejte znaky české abecedy, pomlčky a čísla - jiné znaky jsou v username zakázány", "ERROR");
                return;
            }
            if (!KontrolaTextVstupu.KontrolaJmen(PrijmeniTB.Text))
            {
                MessageBox.Show("Prosím používejte znaky české abecedy a pomlčky - jiné znaky jsou v příjmení zakázány.", "ERROR");
                return;
            }
            if (!KontrolaTextVstupu.KontrolaJmen(KrestniTB.Text))
            {
                MessageBox.Show("Prosím používejte znaky české abecedy a pomlčky - jiné znaky jsou v křestním jméně zakázány.", "ERROR");
                return;
            }


            User novyUser = new User(GeneratorID.VygenerujUserID(), UsernameTB.Text, KrestniTB.Text, PrijmeniTB.Text, SifrovaniHesla.Sifruj(UsernameTB.Text,HesloTB.Text), IsAdminCheckB.Checked, VynuceniZmenyHeslaCheckB.Checked, false);
            PromenneProVsechnyForms.UsersList.Add(novyUser);
            ReloadListBoxUseru();
            MessageBox.Show("Uživatel byl úspěšně přidán", "SUCCESS");
        }

        private void ReloadListBoxUseru() 
        {
            UserLB.Items.Clear();
            UserLB.Items.Add("UserID|Username|KřestníJ.|Příjmení|LastLogin|MáAdminPráva|MáVyuncenouZměnuHesla"); //hlavička
            UserLB.Items.Add("");

            foreach (User u in PromenneProVsechnyForms.UsersList)
            {
                string[] informaceOUzivateli = u.ToString().Split('|');
                string zaznamDoTabulky;
                if (informaceOUzivateli[5] == new DateTime().ToString())
                {
                    zaznamDoTabulky = $"{informaceOUzivateli[0]}|{informaceOUzivateli[1]}|{informaceOUzivateli[2]}|{informaceOUzivateli[3]}|Nemá žádný login|{informaceOUzivateli[6]}|{informaceOUzivateli[7]}";
                }
                else
                {
                    zaznamDoTabulky = $"{informaceOUzivateli[0]}|{informaceOUzivateli[1]}|{informaceOUzivateli[2]}|{informaceOUzivateli[3]}|{informaceOUzivateli[5]}|{informaceOUzivateli[6]}|{informaceOUzivateli[7]}";
                }
                UserLB.Items.Add(zaznamDoTabulky);
                UserLB.Items.Add("");
            }
        }
    }
}

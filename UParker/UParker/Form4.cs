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
    public partial class Form4 : Form
    {
        //Form slouží pro práci se systémem ze strany admina = main-page admina

        User prihlasenyAdmin;
        DateTime currentLoginTime;

        public Form4(User adminTohotoFormu, DateTime loginCas)
        {
            prihlasenyAdmin = adminTohotoFormu;
            currentLoginTime = loginCas;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            HlavickaL.Text = $"User: {prihlasenyAdmin.KrestniJmeno}, {prihlasenyAdmin.Prijmeni} - admin přístup admina {prihlasenyAdmin.Username}";

            UserIDL.Text = prihlasenyAdmin.UserID;
            if (prihlasenyAdmin.LastLoginDatumACas != new DateTime())
            {
                LastLoginTimeL.Text = prihlasenyAdmin.LastLoginDatumACas.ToString("dd.MM.yyyy HH:mm");
            }

            UsersVSystemuLB.Items.Clear();
            UsersVSystemuLB.Items.Add("UserID|Username|KřestníJ.|Příjmení|LastLogin|MáAdminPráva|MáVyuncenouZměnuHesla"); //hlavička
            UsersVSystemuLB.Items.Add("");

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
                UsersVSystemuLB.Items.Add(zaznamDoTabulky);
                UsersVSystemuLB.Items.Add("");
            }

            if (prihlasenyAdmin.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy)
            {
                MessageBox.Show("Od poslední návštěvy Vám byla zrušena nějaká rezervace systémem - prosím zkontrolujte", "Upozornění");
                prihlasenyAdmin.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy = false;
            }

            ModyRazeniCB.SelectedIndex = 0;
            ModyRozsahuCB.SelectedIndex = 0;
        }

        private void LoadRezervaceB_Click(object sender, EventArgs e)
        {
            //načte dle parametrů listbox rezervací
            if (ModyRozsahuCB.SelectedIndex != 0 && ModyRazeniCB.SelectedIndex != 0)
            {
                LoadRezervaceToListBox();
            }
            else 
            {
                MessageBox.Show("Vyplněte módy náhledu - jeden, či oba módy mají prázdný vstup", "ERROR");
            }
        }

        private void LoadRezervaceToListBox() 
        {
            RezervaceVSystemuLB.Items.Clear();
            List<Rezervace> vyfiltrovaneRezervace = new List<Rezervace>();

            if (ModyRozsahuCB.SelectedIndex == 1)
            {
                //aktuální
                foreach (Rezervace rezervace in PromenneProVsechnyForms.RezervaceList)
                {
                    if (rezervace.Stav == "Neproběhlo")
                    {
                        vyfiltrovaneRezervace.Add(rezervace);
                    }
                }
                List<string> serazeneRezervaceDoLB = SeradRezervaceDoStringListuDleVyberu(vyfiltrovaneRezervace, ModyRazeniCB.SelectedIndex);
                foreach (string s in serazeneRezervaceDoLB)
                {
                    RezervaceVSystemuLB.Items.Add(s);
                }
            }
            else 
            {
                //historické
                foreach (Rezervace rezervace in PromenneProVsechnyForms.RezervaceList)
                {
                    vyfiltrovaneRezervace.Add(rezervace);
                }
                List<string> serazeneRezervaceDoLB = SeradRezervaceDoStringListuDleVyberu(vyfiltrovaneRezervace, ModyRazeniCB.SelectedIndex);
                foreach (string s in serazeneRezervaceDoLB)
                {
                    RezervaceVSystemuLB.Items.Add(s);
                }
            }
        }

        private List<string> SeradRezervaceDoStringListuDleVyberu(List<Rezervace> vyfiltrovaneRezervace, int indexRazeni) 
        {
            List<string> vyslednyList = new List<string>();
            if (indexRazeni == 1)
            {
                //neřaď
                vyslednyList.Add("RezrvaceID|UserID|DatumOd|DatumDo|VozidloID|Stav"); //přidá hlavičku
                vyslednyList.Add("");

                foreach (Rezervace r in vyfiltrovaneRezervace)
                {
                    vyslednyList.Add(r.ToString());
                    vyslednyList.Add("");
                }
            }

            if (indexRazeni == 2)
            {
                //řaď dle osob
                vyslednyList.Add("RezrvaceID|UserID|DatumOd|DatumDo|VozidloID|Stav"); //přidá hlavičku
                vyslednyList.Add("");

                List<string> pomocnyUserIDList = new List<string>();
                foreach (Rezervace rezervace in vyfiltrovaneRezervace)
                {
                    string userID = rezervace.ToString().Split('|')[1];
                    pomocnyUserIDList.Add(userID);
                }

                pomocnyUserIDList.Sort();

                for (int i = 0; i < vyfiltrovaneRezervace.Count; i++)
                {
                    //přidej mezeru pokud se nebude opakovat stejné User ID
                    if (i > 0)
                    {
                        if (pomocnyUserIDList[i - 1] != pomocnyUserIDList[i])
                        {
                            vyslednyList.Add("");
                        }
                    }

                    foreach (Rezervace rezervace in vyfiltrovaneRezervace)
                    {
                        if (rezervace.IDUser == pomocnyUserIDList[i] && vyslednyList.IndexOf(rezervace.ToString()) == -1)
                        {
                            vyslednyList.Add(rezervace.ToString());
                            break;
                        }
                    }
                }
            }

            if (indexRazeni == 3)
            {
                //řaď dle aut
                vyslednyList.Add("RezrvaceID|VozidloID|UserID|DatumOd|DatumDo|Stav"); //přidá hlavičku - zde se liší pozice Vozidla ID
                vyslednyList.Add("");
                
                List<string> pomocnyAutoIDList = new List<string>();
                foreach (Rezervace rezervace in vyfiltrovaneRezervace)
                {
                    string autoID = rezervace.ToString().Split('|')[4];
                    pomocnyAutoIDList.Add(autoID);
                }

                pomocnyAutoIDList.Sort();

                for (int i = 0; i < vyfiltrovaneRezervace.Count; i++)
                {
                    //přidej mezeru pokud se nebude opakovat stejné Auto ID
                    if(i > 0) 
                    {
                        if(pomocnyAutoIDList[i-1] != pomocnyAutoIDList[i]) 
                        {
                            vyslednyList.Add("");
                        }
                    }

                    foreach (Rezervace rezervace in vyfiltrovaneRezervace)
                    {
                        string[] splitRezervaciProIndexOf = rezervace.ToString().Split('|');
                        string reformatovanaRezervaceProIndexOf = $"{splitRezervaciProIndexOf[0]}|{splitRezervaciProIndexOf[4]}|{splitRezervaciProIndexOf[1]}|{splitRezervaciProIndexOf[2]}|{splitRezervaciProIndexOf[3]}|{splitRezervaciProIndexOf[5]}";
                        if (rezervace.IDAuta == pomocnyAutoIDList[i] && vyslednyList.IndexOf(reformatovanaRezervaceProIndexOf) == -1)
                        {
                            string[] rezervaceDleAutoHlavicky = rezervace.ToString().Split('|');
                            string reformatovany = $"{rezervaceDleAutoHlavicky[0]}|{rezervaceDleAutoHlavicky[4]}|{rezervaceDleAutoHlavicky[1]}|{rezervaceDleAutoHlavicky[2]}|{rezervaceDleAutoHlavicky[3]}|{rezervaceDleAutoHlavicky[5]}";
                            vyslednyList.Add(reformatovany);
                            break;
                        }
                    }
                }
            }

            if(vyslednyList.Count <= 0) 
            {
                throw new ArgumentOutOfRangeException("Index řazení je out-of-range");
            }
            
            return vyslednyList;
        }

        private void SingleUserControlB_Click(object sender, EventArgs e)
        {
            foreach(User u in PromenneProVsechnyForms.UsersList) 
            {
                if(u.UserID == UserControlIDTB.Text) 
                {
                    Form2 userFormOkupovany = new Form2(u, prihlasenyAdmin, currentLoginTime);
                    userFormOkupovany.Show(); 
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("Nebyl nalezen user s tímto ID - zkuste zkontrolovat ID", "ERROR");
        }

        private void ShowAutoFullInfoB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bylo otevřeno nové okno pro full-auto-control", "Nové okno");
            Form7 autoControl = new Form7();
            autoControl.Show();
        }

        private void AddRezervB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bylo otevřeno nové okno pro rezervace", "Nové okno");
            Form3 addRezervaceForm = new Form3(prihlasenyAdmin, true);
            addRezervaceForm.Show();
            
        }

        private void OdstranitRezervB_Click(object sender, EventArgs e)
        {
            //odstraní rezervaci s daným ID
            for (int i = 0; i < PromenneProVsechnyForms.RezervaceList.Count(); i++)
            {
                if (PromenneProVsechnyForms.RezervaceList[i].IDRezervace == RemoveRezervIDTB.Text)
                {
                    if (PromenneProVsechnyForms.RezervaceList[i].Stav == "Neproběhlo")
                    {
                        MessageBox.Show("Rezervace byla úspěšně zrušena");
                        PromenneProVsechnyForms.RezervaceList[i].NastavStav("Zrušeno - adminem");

                        foreach(User u in PromenneProVsechnyForms.UsersList) 
                        {
                            if(u.UserID == PromenneProVsechnyForms.RezervaceList[i].IDUser) 
                            {
                                u.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy = true;
                                break;
                            }
                        }

                        //znovu načti ListBoxy
                        if (ModyRozsahuCB.SelectedIndex != 0 && ModyRazeniCB.SelectedIndex != 0)
                        {
                            LoadRezervaceToListBox();
                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Rezervace s tímto ID byla již zrušena či již proběhla", "ERROR");
                        return;
                    }
                }
            }
            MessageBox.Show("Nebyla nalezena rezervace s tímto ID - zkuste zkontrolovat ID", "ERROR");
        }

        private void ShowAllUserControlB_Click(object sender, EventArgs e)
        {
            //pustí do ALL-user control módu
            MessageBox.Show("Bylo otevřeno nové okno pro full-user-control", "Nové okno");
            Form8 userControl = new Form8(prihlasenyAdmin.UserID);
            userControl.Show();
        }

        private void AktualizovatLogin()
        {
            prihlasenyAdmin.LastLoginDatumACas = currentLoginTime;
        }

        private void BackB_Click(object sender, EventArgs e)
        {
            AktualizovatLogin();

            Form1 minulyForm = new Form1();
            minulyForm.Show();
            this.Hide();
        }

        private void NactiOpetUsersB_Click(object sender, EventArgs e)
        {
            UsersVSystemuLB.Items.Clear();
            UsersVSystemuLB.Items.Add("UserID|Username|KřestníJ.|Příjmení|LastLogin|MáAdminPráva|MáVyuncenouZměnuHesla"); //hlavička
            UsersVSystemuLB.Items.Add("");

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
                UsersVSystemuLB.Items.Add(zaznamDoTabulky);
                UsersVSystemuLB.Items.Add("");
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            AktualizovatLogin();
            MessageBox.Show("Pro ukončení programu zvolte soubor, do kterého uložíte databázi", "Ukončujeme program");
            UlozDoSouboru.UlozVseDoTxtSouboru();
            Environment.Exit(0);
        }
    }
}

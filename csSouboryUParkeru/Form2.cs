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
    public partial class Form2 : Form
    {
        //Form slouží jako hlavní přístupová konzole pro usera

        User prihlasenyUser;
        List<Rezervace> rezervaceTohotoUzivateleList = new List<Rezervace>();
        DateTime currentLogin;

        User adminNaNavsteve;
        DateTime loginCasAdmina;
        bool adminTakenControl;

        public Form2(User prihlaseny, DateTime loginTime)
        {
            adminTakenControl = false;
            prihlasenyUser = prihlaseny;
            currentLogin = loginTime;
            InitializeComponent();
        }

        public Form2(User navstivenyUser, User adminKteryNavstevuje, DateTime casLoginuAdmina)
        {
            adminTakenControl = true;
            prihlasenyUser = navstivenyUser;
            adminNaNavsteve = adminKteryNavstevuje;
            currentLogin = navstivenyUser.LastLoginDatumACas;
            loginCasAdmina = casLoginuAdmina;
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            HlavickaL.Text = $"User: {prihlasenyUser.KrestniJmeno}, {prihlasenyUser.Prijmeni} - rezervace účtu {prihlasenyUser.Username}";
            
            UserIDL.Text = prihlasenyUser.UserID;
            if (prihlasenyUser.LastLoginDatumACas != new DateTime())
            {
                LastLoginTimeL.Text = prihlasenyUser.LastLoginDatumACas.ToString("dd.MM.yyyy HH:mm");
            }

            if (prihlasenyUser.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy)
            {
                MessageBox.Show("Od poslední návštěvy Vám byla zrušena nějaká rezervace systémem - prosím zkontrolujte", "Upozornění");
                prihlasenyUser.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy = false;
            }

            ModListuCB.SelectedIndex = 0;
            if (adminTakenControl) 
            {
                ZmenaHeslaB.Text = "Vynutit změnu hesla";
                MessageBox.Show("Jste na účtu cizího uživatele - tlačítko pro změnu hesla změněno na \"Vynutit změnu hesla\". \nPo skončení práce prosím klikňete na tlačítko Back - to vás vrátí do Vašeho admin formu", "POZOR");
            }
            if(!adminTakenControl && prihlasenyUser.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy) 
            {
                MessageBox.Show("Admin Vám zrušil jednu z Vašich rezervací - prosím zkontrolujte si je");
                prihlasenyUser.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy = false;
            }
        }

        private void AktualizovatLogin()
        {
            if (!adminTakenControl)
            {
                prihlasenyUser.LastLoginDatumACas = currentLogin;
            }
        }

        private void LoadToListBox(bool zobrazitVse)
        {
            RezervaceUseraLB.Items.Clear();
            RezervaceUseraLB.Items.Add("RezrvaceID|VašeID|DatumOd|DatumDo|VozidloID|Stav");
            RezervaceUseraLB.Items.Add("");
            if (zobrazitVse)
            {
                foreach (Rezervace rezervace in PromenneProVsechnyForms.RezervaceList)
                {
                    if (rezervace.IDUser == prihlasenyUser.UserID)
                    {
                        rezervaceTohotoUzivateleList.Add(rezervace);
                        RezervaceUseraLB.Items.Add(rezervace.ToString());
                        RezervaceUseraLB.Items.Add("");
                    }
                }
            }
            else 
            {
                foreach (Rezervace rezervace in PromenneProVsechnyForms.RezervaceList)
                {
                    if (rezervace.IDUser == prihlasenyUser.UserID && rezervace.Stav == "Neproběhlo")
                    {
                        rezervaceTohotoUzivateleList.Add(rezervace);
                        RezervaceUseraLB.Items.Add(rezervace.ToString());
                        RezervaceUseraLB.Items.Add("");
                    }
                }
            }
        }

        private void BackB_Click(object sender, EventArgs e)
        {
            if (adminTakenControl) 
            {
                Form4 adminuvMainForm = new Form4(adminNaNavsteve, loginCasAdmina);
                adminuvMainForm.Show();
                this.Hide();
                return;
            }

            AktualizovatLogin();

            Form1 minulyForm = new Form1();
            minulyForm.Show();
            this.Hide();
        }

        private void OdstranitB_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PromenneProVsechnyForms.RezervaceList.Count(); i++)
            {
                if (PromenneProVsechnyForms.RezervaceList[i].IDRezervace == IDRezervRemTB.Text && PromenneProVsechnyForms.RezervaceList[i].IDUser == prihlasenyUser.UserID)
                {
                    if (PromenneProVsechnyForms.RezervaceList[i].Stav == "Neproběhlo")
                    {
                        if (adminTakenControl)
                        {
                            MessageBox.Show("Rezervace byla zrušena jménem daného uživatele - neuvidí alert o zrušení jeho registrace při loginu");
                        }
                        else
                        {
                            MessageBox.Show("Rezervace byla úspěšně zrušena");
                        }
                        PromenneProVsechnyForms.RezervaceList[i].NastavStav("Zrušeno - uživatelem");
                        if (ModListuCB.SelectedIndex == 1)
                        {
                            LoadToListBox(false);
                        }
                        else
                        {
                            if (ModListuCB.SelectedIndex == 2)
                            {
                                LoadToListBox(true);
                            }
                            else 
                            {
                                RezervaceUseraLB.Items.Clear();
                            }
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
            MessageBox.Show("Nebyla nalezena žádná Vaše rezervace s tímto ID - zkuste zkontrolovat ID", "ERROR");
        }

        private void ShowAutoInfoB_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < PromenneProVsechnyForms.AutaList.Count; i++) 
            {
                if(PromenneProVsechnyForms.AutaList[i].AutoID == IDVozidlaTB.Text) 
                {
                    string[] autoText = PromenneProVsechnyForms.AutaList[i].ToString().Split('|');
                    string textToShow = $"Značka: {autoText[1]}; Model: {autoText[2]}; Typ: {autoText[3]}; Spotřeba (na 100km): {autoText[4]}l";
                    MessageBox.Show(textToShow, "Vozidlo info:");
                    return;
                }
            }
            MessageBox.Show("ID-auta nenalezeno - zkuste zadat ID znovu", "ERROR");
        }

        private void AddB_Click(object sender, EventArgs e)
        {
            //otevři přidat-novou-rezervaci a NEzavírej toto okno
            if (adminTakenControl)
            {
                MessageBox.Show("Bylo otevřeno nové okno pro rezervace přímo jménem tohoto uživatele", "Nové okno");
            }
            else 
            {
                MessageBox.Show("Bylo otevřeno nové okno pro rezervace", "Nové okno");
            }
            Form3 addRezervaceForm = new Form3(prihlasenyUser, false);
            addRezervaceForm.Show();
        }

        private void ZmenaHeslaB_Click(object sender, EventArgs e)
        {
            if (adminTakenControl) 
            {
                prihlasenyUser.MaVynucenouZmenuHesla = true;
                MessageBox.Show("Při příští návětěvě user bude nucen pro změnu hesla", "Vynucena změna hesla");
                return;
            }
            Form5 zmenaHeslaForm = new Form5(prihlasenyUser, false, currentLogin);
            zmenaHeslaForm.Show();
            this.Hide();
        }

        private void ModListuCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModListuCB.SelectedIndex == 1)
            {
                LoadToListBox(false);
            }
            else
            {
                if (ModListuCB.SelectedIndex == 2)
                {
                    LoadToListBox(true);
                }
                else 
                {
                    RezervaceUseraLB.Items.Clear();
                }
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            AktualizovatLogin();

            if (adminTakenControl) 
            {
                adminNaNavsteve.LastLoginDatumACas = loginCasAdmina;
            }
            MessageBox.Show("Pro ukončení programu zvolte soubor, do kterého uložíte databázi", "Ukončujeme program");
            UlozDoSouboru.UlozVseDoTxtSouboru();
            Environment.Exit(0);
        }
    }
}

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
    public partial class Form3 : Form
    {
        //Form slouží pro registrace user i admina 

        User userFormu;
        bool fromAdmin;
        Auto vybraneVozidlo;

        public Form3(User userVolajiciForm, bool isFromAdminForm)
        {
            userFormu = userVolajiciForm;
            fromAdmin = isFromAdminForm;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (fromAdmin)
            {
                HlavickaL.Text = "Přidat rezervaci (admin-view)";
                UserL.Visible = false;
                UserIDTB.Visible = true;
                UserORUserIDL.Text = "User-ID:";
            }
            else 
            {
                HlavickaL.Text = "Přidat rezervaci (user-view)";
                UserL.Visible = true;
                UserL.Text = $"{userFormu.Username} - {userFormu.UserID}";
                UserORUserIDL.Text = "User:";
            }

            ZnackaL.Visible = false;
            ModelL.Visible = false;
            TypL.Visible = false;
            SpotrebaL.Visible = false;
        }
        
        private void AddRezervB_Click(object sender, EventArgs e)
        {
            DateTime odDatum = OdDatumDTP.Value;
            DateTime doDatum = DoDatumDTP.Value;

            if (odDatum.Date < DateTime.Now.Date || doDatum.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Nelze rezervovat v minulosti - operace zrušena", "ERROR");
                return;
            }

            bool dataSeRovnaji = odDatum.Date == doDatum.Date;
            if (odDatum >= doDatum && !(dataSeRovnaji))
            {
                MessageBox.Show("Datum začátku rezervace je po konci rezervace - operace zrušena", "ERROR");
                return;
            }

            string odCas = OdCasTB.Text;
            string doCas = DoCasTB.Text;

            if (TestFormatuCasu(odCas) == false)
            {
                MessageBox.Show("Od čas nemá správný formát (formát: hh:mm - 00-23 : 00-59 - např.: 09:31 nebo 21:00) - operace zrušena", "ERROR");
                return;
            }
            if (TestFormatuCasu(doCas) == false)
            {
                MessageBox.Show("Do čas nemá správný formát (formát: hh:mm - 00-23 : 00-59 - např.: 09:31 nebo 21:00) - operace zrušena", "ERROR");
                return;
            }

            DateTime casOdDT = DateTime.Parse(odCas);
            DateTime casDoDT = DateTime.Parse(doCas);

            if (dataSeRovnaji)
            {
                double hodinyOdDouble = casOdDT.Hour + (Convert.ToDouble(casOdDT.Minute) / 60);
                double hodinyDoDouble = casDoDT.Hour + (Convert.ToDouble(casDoDT.Minute) / 60);
                if (hodinyOdDouble >= hodinyDoDouble)
                {
                    MessageBox.Show("Čas od musí být menší než čas do pokud se jedná o rezervace ve stejném dni", "ERROR");
                    return;
                }
            }


            DateTime finalOd = new DateTime(odDatum.Year, odDatum.Month, odDatum.Day, casOdDT.Hour, casOdDT.Minute, 00);
            DateTime finalDo = new DateTime(doDatum.Year, doDatum.Month, doDatum.Day, casDoDT.Hour, casDoDT.Minute, 00);

            if (vybraneVozidlo.JeDostupneVCas(finalOd, finalDo))
            {
                MessageBox.Show("Rezervace proběhla úspěšně! Pokud chcete můžete okno zavřít a překliknout do minulého okna či můžete přidat další rezervaci", "SUCCESS");
                string rezervaceID = GeneratorID.VygenerujRezervaceID();
                string rezervaterID;
                if (fromAdmin) 
                {
                    rezervaterID = UserIDTB.Text;
                    if (!GeneratorID.ExistujeID(rezervaterID)) 
                    {
                        MessageBox.Show("Uživatel s tímto ID neexistuje - prosím zadejte ID, které již v systému existuje", "ERROR");
                        return;
                    }
                }
                else 
                {
                    rezervaterID = userFormu.UserID;
                }
                Rezervace novaRezervace = new Rezervace(rezervaceID, rezervaterID, finalOd, finalDo, vybraneVozidlo.AutoID);
                PromenneProVsechnyForms.RezervaceList.Add(novaRezervace);
            }
            else
            {
                MessageBox.Show("Změnili jste čas rezervace, ale nenačetli jste si znovu auta - toto auto v tomto čase není dostupné!", "ERROR");
            }
                
            
        }

        private void VozidlaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aktualizuje dle toho popis vozidla
            if (VozidlaCB.SelectedIndex != 0)
            {
                string selectedString = VozidlaCB.SelectedItem.ToString();
                int indexOfID = selectedString.IndexOf("ID: ") + 4;
                string idSelectedVozidla = selectedString.Substring(indexOfID);


                foreach (Auto a in PromenneProVsechnyForms.AutaList)
                {
                    if (a.AutoID == idSelectedVozidla)
                    {
                        vybraneVozidlo = a;
                        string[] autoText = a.ToString().Split('|');
                        ZnackaL.Text = autoText[1];
                        ModelL.Text = autoText[2];
                        TypL.Text = autoText[3];
                        SpotrebaL.Text = autoText[4] + "l"; 
                        
                        ZnackaL.Visible = true;
                        ModelL.Visible = true;
                        TypL.Visible = true;
                        SpotrebaL.Visible = true;
                    }
                }

                AddRezervB.Visible = true;
            }
            else 
            {
                ZnackaL.Visible = false;
                ModelL.Visible = false;
                TypL.Visible = false;
                SpotrebaL.Visible = false;

                MessageBox.Show("Zvolte prosím auto - ne prázdné místo");
                AddRezervB.Visible = false;
            }
        }

        private bool TestFormatuCasu(string cas)
        {
            if (cas.Contains(':'))
            {
                string[] poleHodinAMinut = cas.Split(':');
                if (poleHodinAMinut.Length == 2)
                {
                    if (poleHodinAMinut[0].Length == 2 && poleHodinAMinut[1].Length == 2)
                    {
                        if (int.TryParse(poleHodinAMinut[0], out int i) && int.TryParse(poleHodinAMinut[1], out int y))
                        {
                            i = int.Parse(poleHodinAMinut[0]);
                            y = int.Parse(poleHodinAMinut[1]);

                            if (i >= 0 && i <= 23 && y >= 0 && y <= 59)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void ZobrazitAutaB_Click(object sender, EventArgs e)
        {
            AddRezervB.Visible = false;

            DateTime odDatum = OdDatumDTP.Value;
            DateTime doDatum = DoDatumDTP.Value;
            
            if(odDatum.Date < DateTime.Now.Date || doDatum.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Nelze rezervovat v minulosti - operace zrušena", "ERROR");
                return;
            }

            bool dataSeRovnaji = odDatum.Date == doDatum.Date;
            if (odDatum >= doDatum && !(dataSeRovnaji)) 
            {
                MessageBox.Show("Datum začátku rezervace je po konci rezervace - operace zrušena", "ERROR");
                return;
            }

            string odCas = OdCasTB.Text;
            string doCas = DoCasTB.Text;
            
            if (TestFormatuCasu(odCas) == false)
            {
                MessageBox.Show("Od čas nemá správný formát (formát: hh:mm - 00-23 : 00-59 - např.: 09:31 nebo 21:00) - operace zrušena", "ERROR");
                return;
            }
            if (TestFormatuCasu(doCas) == false)
            {
                MessageBox.Show("Do čas nemá správný formát (formát: hh:mm - 00-23 : 00-59 - např.: 09:31 nebo 21:00) - operace zrušena", "ERROR");
                return;
            }

            DateTime casOdDT = DateTime.Parse(odCas);
            DateTime casDoDT = DateTime.Parse(doCas);

            if (dataSeRovnaji) 
            {
                double hodinyOdDouble = casOdDT.Hour + (Convert.ToDouble(casOdDT.Minute) / 60);
                double hodinyDoDouble = casDoDT.Hour + (Convert.ToDouble(casDoDT.Minute) / 60);
                if(hodinyOdDouble >= hodinyDoDouble) 
                {
                    MessageBox.Show("Čas od musí být menší než čas do pokud se jedná o rezervace ve stejném dni", "ERROR");
                    return;
                }
            }


            DateTime finalOd = new DateTime(odDatum.Year, odDatum.Month, odDatum.Day, casOdDT.Hour, casOdDT.Minute, 00);
            DateTime finalDo = new DateTime(doDatum.Year, doDatum.Month, doDatum.Day, casDoDT.Hour, casDoDT.Minute, 00);

            ZnackaL.Visible = false;
            ModelL.Visible = false;
            TypL.Visible = false;
            SpotrebaL.Visible = false;

            NactiAuta(finalOd, finalDo);
        }

        private void NactiAuta(DateTime odDAC, DateTime doDAC) 
        {
            //zde budou načteny auta, které nejsou v této době zaregistrované
            VozidlaCB.Items.Clear();
            VozidlaCB.Items.Add("");
            VozidlaCB.SelectedIndex = 0;

            foreach (Auto a in PromenneProVsechnyForms.AutaList) 
            {
                if(a.JeDostupneVCas(odDAC, doDAC)) 
                {
                    string[] autoText = a.ToString().Split('|');
                    string doListu = $"Značka: {autoText[1]}; Model: {autoText[2]}; ID: {autoText[0]}";
                    VozidlaCB.Items.Add(doListu);
                }
            }
            if(VozidlaCB.Items.Count > 1) 
            {
                VozidlaCB.Visible = true;
                InfoProUserL.Visible = false;
                MessageBox.Show("Zvolte prosím auto");
            }
            else 
            {
                VozidlaCB.Visible = false;
                InfoProUserL.Visible = true;
                MessageBox.Show("V tomto čase nejsou žádná volná vozidla - zkuste jiný termín", "Komplikace");
            }
        }
    }
}

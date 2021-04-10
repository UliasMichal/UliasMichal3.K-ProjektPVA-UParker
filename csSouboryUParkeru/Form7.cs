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
    public partial class Form7 : Form
    {
        //Form slouží pro správu aut v systému

        public List<NakladyAuta> listNakladuNovehoAuta = new List<NakladyAuta>();

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            listNakladuNovehoAuta.Clear();
            NakladyLB.Items.Clear();
            RefreashListBox();
            NakladyLB.Items.Add("Č.faktury|PopisNákladu|DatumVzniknutíNákladu|ČasováNáročnost(dny:hodiny:minuty)|Cena"); //hlavička
            NakladyLB.Items.Add("");

        }

        private void RefreashListBox() 
        {
            AutaLB.Items.Clear();
            AutaLB.Items.Add("AutoID|Značka|Model|Typ|Spotřeba(l/100km)|Stav|(NedostupnéDo)"); //hlavička LB
            AutaLB.Items.Add("");
            foreach (Auto a in PromenneProVsechnyForms.AutaList) 
            {
                AutaLB.Items.Add(a.ToString());
                AutaLB.Items.Add("");
            }
        }

        private void ReloadAutaVSystemuB_Click(object sender, EventArgs e)
        {
            RefreashListBox();
        }

        private void AddNakladNovehoAutaB_Click(object sender, EventArgs e)
        {
            if (!ValidaceVstupuVTextBoxuProNedostupnost(DatumNakladuDTP.Value, CasNakladuTB.Text, true))
            {
                return;
            }

            if(CisloFakturyTB.Text.Length < 0 || CenaNakladuTB.Text.Length < 0 || PopisNakladuTB.Text.Length < 0) 
            {
                MessageBox.Show("Vstupy nesmí být prázdné - minimálně je potřeba 1 znak", "ERROR");
                return;
            }

            if (!KontrolaTextVstupu.KontrolaVolnychVstupu(CisloFakturyTB.Text))
            {
                MessageBox.Show("Prosím nepoužívejte znak | v čísle faktury", "ERROR");
            }
            if (!KontrolaTextVstupu.KontrolaVolnychVstupu(PopisNakladuTB.Text)) 
            {
                MessageBox.Show("Prosím nepoužívejte znak | v popis nákladu", "ERROR");
            }

            string casovaNarocnostString = CasovaNarocnostTB.Text;
            if (casovaNarocnostString.Contains(':'))
            {
                string[] poleHodinAMinut = casovaNarocnostString.Split(':');
                if (poleHodinAMinut.Length == 3)
                {
                    if (poleHodinAMinut[0].Length == 2 && poleHodinAMinut[1].Length == 2 && poleHodinAMinut[2].Length == 2)
                    {
                        if (int.TryParse(poleHodinAMinut[0], out int i) && int.TryParse(poleHodinAMinut[1], out int y) && int.TryParse(poleHodinAMinut[1], out int z))
                        {
                            i = int.Parse(poleHodinAMinut[0]);
                            y = int.Parse(poleHodinAMinut[1]);
                            z = int.Parse(poleHodinAMinut[2]);

                            if (i >= 0 && i <= 23 && y >= 0 && y <= 59 && z <= 99)
                            {
                                //correct vstup
                            }
                            else
                            {
                                MessageBox.Show("Časová náročnost nemá správný formát", "ERROR");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Časová náročnost nemá správný formát", "ERROR");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Časová náročnost nemá správný formát", "ERROR");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Časová náročnost nemá správný formát", "ERROR");
                    return;
                }
            }
            else 
            {
                MessageBox.Show("Časová náročnost nemá správný formát", "ERROR");
                return;
            }

            DateTime datum = DatumNakladuDTP.Value;

            DateTime cas = DateTime.Parse(CasNakladuTB.Text);

            DateTime datumACas = new DateTime(datum.Year, datum.Month, datum.Day, cas.Hour, cas.Minute, 00);

            decimal cena;
            if (decimal.TryParse(CenaNakladuTB.Text, out cena)) 
            {
                
                cena = decimal.Parse(CenaNakladuTB.Text);
            }
            else 
            {
                MessageBox.Show("Nelze překonvertovat cenu na číslo", "ERROR");
                return;
            }

            NakladyAuta novyNaklad = new NakladyAuta(CisloFakturyTB.Text, PopisNakladuTB.Text, DatumNakladuDTP.Value, TimeSpan.Parse(CasovaNarocnostTB.Text), cena);
            listNakladuNovehoAuta.Add(novyNaklad);
            string reformatovanyNaklad = $"{CisloFakturyTB.Text}|{PopisNakladuTB.Text}|{datumACas.ToString("dd.MM.yyyy HH:mm")}|{TimeSpan.Parse(CasovaNarocnostTB.Text).ToString()}|{cena}";
            NakladyLB.Items.Add(reformatovanyNaklad);
            NakladyLB.Items.Add("");
        }

        private void AddAutoB_Click(object sender, EventArgs e)
        {
            string idNovehoAuta = GeneratorID.VygenerujAutoID();
            for(int i = 0; i < listNakladuNovehoAuta.Count; i++) 
            {
                listNakladuNovehoAuta[i].AutoID = idNovehoAuta;
                PromenneProVsechnyForms.NakladyList.Add(listNakladuNovehoAuta[i]);
            }

            if (!KontrolaTextVstupu.KontrolaUsernameANazvuAut(ZnackaNovehoAutaTB.Text))
            {
                MessageBox.Show("Prosím používejte znaky české abecedy, pomlčky a čísla - jiné znaky jsou ve značce auta zakázány", "ERROR");
            }
            if (!KontrolaTextVstupu.KontrolaUsernameANazvuAut(ModelNovehoAutaTB.Text))
            {
                MessageBox.Show("Prosím používejte znaky české abecedy, pomlčky a čísla - jiné znaky jsou v názvu modelu auta zakázány", "ERROR");
            }
            if (!KontrolaTextVstupu.KontrolaJmen(TypNovehoAutaTB.Text))
            {
                MessageBox.Show("Prosím používejte znaky české abecedy a pomlčky - jiné znaky jsou zakázány v popisu typu auta.", "ERROR");
            }


            double spotrebaD = 0;
            if (ModelNovehoAutaTB.Text.Length != 0 && ZnackaNovehoAutaTB.Text.Length != 0 && TypNovehoAutaTB.Text.Length != 0) 
            {
                if(double.TryParse(SpotrebaNovehoAutaTB.Text, out spotrebaD)) 
                {
                    spotrebaD = double.Parse(SpotrebaNovehoAutaTB.Text);
                    if(spotrebaD <= 0) 
                    {
                        MessageBox.Show("Spotřeba nesmí být menší nebo rovna než 0", "ERROR");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Spotřeba musí být desetinné číslo", "ERROR");
                    return;
                }
            }
            else 
            {
                MessageBox.Show("Model, značka či typ je prázdný - toto nesmí nastat", "ERROR");
                return;
            }

            Auto noveAuto = new Auto(idNovehoAuta, ZnackaNovehoAutaTB.Text, ModelNovehoAutaTB.Text, TypNovehoAutaTB.Text, spotrebaD, "D", "-", listNakladuNovehoAuta);
            PromenneProVsechnyForms.AutaList.Add(noveAuto);
            MessageBox.Show("Auto úspěšně přidáno do systému - pokud chcete můžete zavřít toto okno, přidat další auto, či dokonce otevřít správce nákladů v systému", "SUCCESS");
            RefreashListBox();
        }

        private void ResetNakladuNovehoAutaB_Click(object sender, EventArgs e)
        {
            listNakladuNovehoAuta.Clear();
            NakladyLB.Items.Clear();
            NakladyLB.Items.Add("Č.faktury|PopisNákladu|DatumVzniknutíNákladu|ČasováNáročnost(dny:hodiny:minuty)|Cena"); //hlavička
            NakladyLB.Items.Add("");

        }

        private bool ValidaceVstupuVTextBoxuProNedostupnost(DateTime datumZDTP, string casString, bool lzeVMinulosti) 
        {
            if (TestFormatuCasu(casString) == false)
            {
                MessageBox.Show("Čas nemá správný formát (formát: hh:mm - 00-23 : 00-59 - např.: 09:31 nebo 21:00) - operace zrušena", "ERROR");
                return false;
            }

            DateTime datum = datumZDTP;

            DateTime cas = DateTime.Parse(casString);

            DateTime nedostupneDoDatumACas = new DateTime(datum.Year, datum.Month, datum.Day, cas.Hour, cas.Minute, 00);

            if (lzeVMinulosti == false)
            {
                if (nedostupneDoDatumACas < DateTime.Now)
                {
                    MessageBox.Show("Nelze nastavit v minulosti", "ERROR");
                    return false;
                }
            }
            return true;
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

        private void NastavitNedostupnostB_Click(object sender, EventArgs e)
        {
            if (!GeneratorID.ExistujeID(IDAutaNedostupnehoTB.Text)) 
            {
                MessageBox.Show("Auto s tímto ID neexistuje", "ERROR");
                return;
            }

            if (NedostupneDoOdvolaniCheckB.Checked)
            {
                foreach (Auto a in PromenneProVsechnyForms.AutaList)
                {
                    if (a.AutoID == IDAutaNedostupnehoTB.Text)
                    {
                        a.NastavitNedostupnost();

                        List<string> userIDList = new List<string>();

                        foreach (Rezervace r in PromenneProVsechnyForms.RezervaceList)
                        {
                            if (r.IDAuta == a.AutoID && r.Stav == "Neproběhlo")
                            {
                                r.NastavStav("Zrušeno - vozidlo mimo provoz");
                                if (!userIDList.Contains(r.IDUser))
                                {
                                    userIDList.Add(r.IDUser);
                                }
                            }
                        }

                        foreach (User u in PromenneProVsechnyForms.UsersList)
                        {
                            if (userIDList.Contains(u.UserID))
                            {
                                u.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy = true;
                            }
                        }

                        MessageBox.Show("Auto mimo provoz do odvolání", "SUCCESS");
                        RefreashListBox();
                        return;
                    }
                }
            }
            else
            {
                if(!ValidaceVstupuVTextBoxuProNedostupnost(NedostupneDoDatumDTP.Value, NedostupneDoCasuTB.Text, false)) 
                {
                    return;
                }
                foreach (Auto a in PromenneProVsechnyForms.AutaList)
                {
                    if (a.AutoID == IDAutaNedostupnehoTB.Text)
                    {
                        DateTime datum = NedostupneDoDatumDTP.Value;

                        DateTime cas = DateTime.Parse(NedostupneDoCasuTB.Text);

                        DateTime nedostupneDoDatumACas = new DateTime(datum.Year, datum.Month, datum.Day, cas.Hour, cas.Minute, 00);

                        a.NastavitNedostupnost(nedostupneDoDatumACas);
                        

                        List<string> userIDList = new List<string>();

                        foreach (Rezervace r in PromenneProVsechnyForms.RezervaceList)
                        {
                            if (r.IDAuta == a.AutoID && r.Stav == "Neproběhlo" && r.DatumACasDo < nedostupneDoDatumACas)
                            {
                                r.NastavStav("Zrušeno - vozidlo mimo provoz");
                                if (!userIDList.Contains(r.IDUser))
                                {
                                    userIDList.Add(r.IDUser);
                                }
                            }
                        }

                        foreach (User u in PromenneProVsechnyForms.UsersList)
                        {
                            if (userIDList.Contains(u.UserID))
                            {
                                u.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy = true;
                            }
                        }

                        MessageBox.Show("Auto mimo provoz do: " + nedostupneDoDatumACas.ToString("dd.MM.yyyy HH:mm"), "SUCCESS");
                        RefreashListBox();
                        return;
                    }
                }
            }

        }
    

        private void OtevreniSpravceNakladuB_Click(object sender, EventArgs e)
        {
            //otevření formu 9 - posledního formu programu - pop-up opět
            MessageBox.Show("Bylo otevřeno nové okno pro náklady-control", "Nové okno");
            Form9 spravceNakladu = new Form9();
            spravceNakladu.Show();
        }

        private void OdstranitAutoB_Click(object sender, EventArgs e)
        {
            foreach (Auto a in PromenneProVsechnyForms.AutaList)
            {
                if(a.AutoID == RemoveAutoByIDTB.Text) 
                {
                    a.OdstranitZeSystemu();

                    foreach (Rezervace r in PromenneProVsechnyForms.RezervaceList)
                    {
                        if (r.Stav == "Neproběhlo")
                        {
                            r.NastavStav("Zrušeno - vozidlo odstraněno");
                            foreach (User u in PromenneProVsechnyForms.UsersList)
                            {
                                if (u.UserID == r.IDUser)
                                {
                                    u.ZrusenaUzivatelskaRezervaceOdPosledniNavstevy = true;
                                }
                            }
                        }
                    }

                    MessageBox.Show("Auto odstraněno ze systému", "SUCCESS");
                    
                    RefreashListBox();

                    return;
                }
            }
            MessageBox.Show("Auto s tímto ID neexistuje - zkontrolujte ID a zkuste znovu", "ERROR");
        }

        private void NastavitDostupnostB_Click(object sender, EventArgs e)
        {
            if (!GeneratorID.ExistujeID(IDAutaNedostupnehoTB.Text))
            {
                MessageBox.Show("Auto s tímto ID neexistuje", "ERROR");
                return;
            }
            foreach (Auto a in PromenneProVsechnyForms.AutaList)
            {
                if (a.AutoID == IDAutaNedostupnehoTB.Text)
                {
                    a.NastavitDostupnost();
                    MessageBox.Show("Vozidlo bylo opět nastaveno na dostupné", "SUCCESS");
                    RefreashListBox();
                    break;
                }
            }
        }
              
    }
}

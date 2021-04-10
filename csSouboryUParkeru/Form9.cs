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
    public partial class Form9 : Form
    {
        //Form určen pro správu servisních úkonů aut - jejich přehled + možnost přidání

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            NactiNaklady("");
        }

        private void NactiNaklady(string id) 
        {
            if(id.Length == 0) 
            {
                NakladyLB.Items.Clear();
                NakladyLB.Items.Add("Č.Faktury|AutoID|Popis|ČasVytvořeníNákladu|ČasováNáročnost|Cena"); //hlavička
                NakladyLB.Items.Add("");

                foreach(NakladyAuta nA in PromenneProVsechnyForms.NakladyList) 
                {
                    NakladyLB.Items.Add(nA.ToString());
                    NakladyLB.Items.Add("");
                }
            }
            else 
            {
                if (GeneratorID.ExistujeID(id)) 
                {
                    Auto autoKtereHledame = new Auto();
                    foreach(Auto a in PromenneProVsechnyForms.AutaList) 
                    {
                        if(a.AutoID == id) 
                        {
                            autoKtereHledame = a;
                            break;
                        }
                    }
                    NakladyLB.Items.Clear();
                    NakladyLB.Items.Add("Náklady vozidla: " + id);
                    NakladyLB.Items.Add("Č.Faktury|AutoID|Popis|ČasVytvořeníNákladu|ČasováNáročnost|Cena"); //hlavička
                    NakladyLB.Items.Add("");

                    foreach (NakladyAuta nA in autoKtereHledame.NakladyTohotoAuta)
                    {
                        NakladyLB.Items.Add(nA.ToString());
                        NakladyLB.Items.Add("");
                    }
                }
                else 
                {
                    MessageBox.Show("Zadané ID neexistuje - buď nechte pole prázdné pro vypsání všech rezervací, nebo napište validní ID", "ERROR");
                    return;
                }
            }
        }

        private void VypsatNakladAutaB_Click(object sender, EventArgs e)
        {
            NactiNaklady(VypsatNakladyByIDTB.Text);
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

        private void ValidaceDatumuACasu(DateTime datumZDTP, string casString, bool lzeVMinulosti)
        {
            if (TestFormatuCasu(casString) == false)
            {
                MessageBox.Show("Čas nemá správný formát (formát: hh:mm - 00-23 : 00-59 - např.: 09:31 nebo 21:00) - operace zrušena", "ERROR");
                return;
            }

            DateTime datum = datumZDTP;

            DateTime cas = DateTime.Parse(casString);

            DateTime datumACas = new DateTime(datum.Year, datum.Month, datum.Day, cas.Hour, cas.Minute, 00);

            if (lzeVMinulosti == false)
            {
                if (datumACas < DateTime.Now)
                {
                    MessageBox.Show("Nelze nastavit v minulosti", "ERROR");
                    return;
                }
            }
        }

        private void AddNovyNakladAutaB_Click(object sender, EventArgs e)
        {
            if (!GeneratorID.ExistujeID(AutoIDTB.Text))
            {
                MessageBox.Show("Dané auto neexistuje - zvolte validní ID", "ERROR");
                return;
            }

            

            ValidaceDatumuACasu(DatumNakladuDTP.Value, CasNakladuTB.Text, true);

            DateTime datum = DatumNakladuDTP.Value;

            DateTime cas = DateTime.Parse(CasNakladuTB.Text);

            DateTime datumACas = new DateTime(datum.Year, datum.Month, datum.Day, cas.Hour, cas.Minute, 00);

            if (CisloFakturyTB.Text.Length < 0 || CenaNakladuTB.Text.Length < 0 || PopisNakladuTB.Text.Length < 0)
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
            
            TimeSpan casovaNarocnostTimeSpan = TimeSpan.Parse(casovaNarocnostString);


            NakladyAuta novyNaklad = new NakladyAuta(CisloFakturyTB.Text, AutoIDTB.Text, PopisNakladuTB.Text, datumACas, casovaNarocnostTimeSpan, cena);
            PromenneProVsechnyForms.NakladyList.Add(novyNaklad);
            foreach(Auto a in PromenneProVsechnyForms.AutaList) 
            {
                if(a.AutoID == AutoIDTB.Text) 
                {
                    a.NakladyTohotoAuta.Add(novyNaklad);
                    MessageBox.Show("Úspěšně byla přidán náklad - pozn.: pro aktualizaci listboxu vypište jeho obsah znovu", "SUCCESS");
                    break;
                }
            }
        }
    }

}

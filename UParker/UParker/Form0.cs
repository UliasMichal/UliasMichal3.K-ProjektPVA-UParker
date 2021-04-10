using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UParker
{
    public partial class Form0 : Form
    {
        //Form slouží pro načtení databáze z TXT file a dělá kontrolu daného souboru

        public Form0()
        {
            InitializeComponent();
        }

        private void BrandNewB_Click(object sender, EventArgs e)
        {
            OpenFileDialog vyberFileDialog = new OpenFileDialog();
            if (vyberFileDialog.ShowDialog() == DialogResult.OK) 
            {
                string path = vyberFileDialog.FileName;
                string[] defaultSettings = {
                "UParker.txt",
                "",
                "Users:",
                "U1010AS|Admin|Admin|Admin|VBWyfB5VDCSei29dEF==||True|False|False",
                "",
                "Auta:",
                "",
                "Naklady:",
                "",
                "Rezervace:",
                ""
                };

                File.WriteAllLines(path, defaultSettings);
                LoadFromFile(path, false);
            }
            else 
            {
                MessageBox.Show("Nebyl vybrán žádný soubor - operace zrušena", "ERROR");
            }
        }

        private void SelectLoadB_Click(object sender, EventArgs e)
        {
            OpenFileDialog vyberFileDialog = new OpenFileDialog();
            if (vyberFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = vyberFileDialog.FileName;
                LoadFromFile(path, true);
            }
            else
            {
                MessageBox.Show("Nebyl vybrán žádný soubor - operace zrušena", "ERROR");
            }
        }

        private bool LoadVracejiciValiditu(string[] radkySouboru) 
        {
            if (radkySouboru[0] == "UParker.txt" && radkySouboru[radkySouboru.Length-1] == "") 
            {
                int nejdelsiUserID = 6;
                int indexZacatkuUseru = Array.IndexOf(radkySouboru, "Users:") + 1;
                int indexKonecUseru = Array.IndexOf(radkySouboru, "", indexZacatkuUseru);
                if(indexKonecUseru - indexZacatkuUseru >= 1) 
                {
                    for(int i = indexZacatkuUseru; i < indexKonecUseru; i++) 
                    {
                        string patternUser = "^(U\\d*[A-Z]{2})\\|([a-zA-ZěščřžýáíéóúůďťňĎŇŤŠČŘŽÝÁÍÉÚŮ 0-9-]*)\\|([a-zA-ZěščřžýáíéóúůďťňĎŇŤŠČŘŽÝÁÍÉÚŮ -]*)\\|([a-zA-ZěščřžýáíéóúůďťňĎŇŤŠČŘŽÝÁÍÉÚŮ -]*)\\|(.*?)\\|(\\d{1,2}\\.\\d{1,2}\\.\\d\\d\\d\\d \\d\\d:\\d\\d|)\\|(False|True)\\|(False|True)\\|(False|True)$";
                        Regex regex = new Regex(patternUser);
                        if (regex.IsMatch(radkySouboru[i]) == false)
                        {
                            return false;
                        }
                        else 
                        {
                            GroupCollection gc = regex.Match(radkySouboru[i]).Groups;
                            if (GeneratorID.ExistujeID(gc[1].ToString())) 
                            {
                                MessageBox.Show("V souboru nalezeno duplictní user ID: " + gc[1], "ERROR");
                                return false;
                            }
                            
                            if (gc[6].ToString() == "")
                            {
                                
                                PromenneProVsechnyForms.UsersList.Add(new User(gc[1].ToString(), gc[2].ToString(), gc[3].ToString(), gc[4].ToString(), gc[5].ToString(), bool.Parse(gc[7].ToString()), bool.Parse(gc[8].ToString()), bool.Parse(gc[9].ToString())));
                            }
                            else //"dd.MM.yyyy HH:mm"
                            {
                                PromenneProVsechnyForms.UsersList.Add(new User(gc[1].ToString(), gc[2].ToString(), gc[3].ToString(), gc[4].ToString(), gc[5].ToString(), DateTime.Parse(gc[6].ToString()), bool.Parse(gc[7].ToString()), bool.Parse(gc[8].ToString()), bool.Parse(gc[9].ToString())));
                            }
                            if (gc[1].Length-1 > nejdelsiUserID) 
                            {
                                nejdelsiUserID = gc[1].Length-1;
                            } 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No-User - doporučení: vytvořte defaultní databázi, která obsahuje 1 admin usera", "ERROR");
                    return false;
                }
                PromenneProVsechnyForms.pocetCiferVID = nejdelsiUserID;

                int indexZacatkuAut = Array.IndexOf(radkySouboru, "Auta:") + 1;
                int indexKonecAut = Array.IndexOf(radkySouboru, "", indexZacatkuAut);
                if (indexKonecAut - indexZacatkuAut >= 1)
                {
                    for (int i = indexZacatkuAut; i < indexKonecAut; i++)
                    {
                        string patternAut = "^(A\\d*[A-Z]{2})\\|([a-zA-ZěščřžýáíéóúůďťňĎŇŤŠČŘŽÝÁÍÉÚŮ 0-9-]*)\\|([a-zA-ZěščřžýáíéóúůďťňĎŇŤŠČŘŽÝÁÍÉÚŮ 0-9-]*)\\|([a-zA-ZěščřžýáíéóúůďťňĎŇŤŠČŘŽÝÁÍÉÚŮ -]*)\\|(\\d+\\.?\\d*)\\|(MP|D)\\|(DoOdvolani|Odstraneno|-|\\d{1,2}\\.\\d{1,2}\\.\\d\\d\\d\\d \\d\\d:\\d\\d)$";
                        Regex regex = new Regex(patternAut);
                        if (regex.IsMatch(radkySouboru[i]) == false)
                        {
                            return false;
                        }
                        else 
                        {
                            GroupCollection gc = regex.Match(radkySouboru[i]).Groups;
                            if (GeneratorID.ExistujeID(gc[1].ToString()))
                            {
                                MessageBox.Show("V souboru nalezeno duplictní auto ID: " + gc[1], "ERROR");
                                return false;
                            }
                            double spotrebaVDouble = double.Parse(gc[5].Value, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                            PromenneProVsechnyForms.AutaList.Add(new Auto(gc[1].Value, gc[2].Value, gc[3].Value, gc[4].Value, spotrebaVDouble, gc[6].Value, gc[7].Value));
                        }
                    }
                }

                int indexZacatkuNakladu = Array.IndexOf(radkySouboru, "Naklady:") + 1;
                int indexKonecNakladu = Array.IndexOf(radkySouboru, "", indexZacatkuNakladu);
                if (indexKonecNakladu - indexZacatkuNakladu >= 1)
                {
                    for (int i = indexZacatkuNakladu; i < indexKonecNakladu; i++)
                    {
                        string patternNakladu = "^(.*?)\\|(A\\d*[A-Z]{2})\\|(.*?)\\|(\\d{1,2}\\.\\d{1,2}\\.\\d\\d\\d\\d \\d\\d:\\d\\d)\\|(\\d\\d:\\d\\d:\\d\\d)\\|-?(\\d*(\\.\\d+)?)$";
                        Regex regex = new Regex(patternNakladu);
                        if (regex.IsMatch(radkySouboru[i]) == false)
                        {
                            return false;
                        }
                        else
                        {
                            GroupCollection gc = regex.Match(radkySouboru[i]).Groups;
                            decimal cenaVDecimal = decimal.Parse(gc[6].Value, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                            NakladyAuta naklad = new NakladyAuta(gc[1].Value, gc[2].Value, gc[3].Value, DateTime.Parse(gc[4].Value), TimeSpan.Parse(gc[5].Value), cenaVDecimal);
                            PromenneProVsechnyForms.NakladyList.Add(naklad);

                            if (GeneratorID.ExistujeID(gc[2].Value)) 
                            {
                                foreach (Auto a in PromenneProVsechnyForms.AutaList)
                                {
                                    if (gc[2].Value == a.AutoID)
                                    {
                                        a.NakladyTohotoAuta.Add(naklad);
                                        break;                                    
                                    }
                                }
                            }
                            else 
                            {
                                MessageBox.Show("V souboru se vyskytuje náklad vázaný na neexistující ID - náklad je navázan na ID auta: " + gc[2].Value, "ERROR");
                                return false;
                            }
                        }
                    }
                }

                int indexZacatkuRezervaci = Array.IndexOf(radkySouboru, "Rezervace:") + 1;
                int indexKonecRezervaci = Array.IndexOf(radkySouboru, "", indexZacatkuRezervaci);
                if (indexKonecRezervaci - indexZacatkuRezervaci >= 1)
                {
                    for (int i = indexZacatkuRezervaci; i < indexKonecRezervaci; i++)
                    {
                        string patternRezervace = "^(R\\d*)\\|(U\\d*[A-Z]{2})\\|(\\d{1,2}\\.\\d{1,2}\\.\\d\\d\\d\\d \\d\\d:\\d\\d)\\|(\\d{1,2}\\.\\d{1,2}\\.\\d\\d\\d\\d \\d\\d:\\d\\d)\\|(A\\d*[A-Z]{2})\\|(Proběhlo|Zrušeno - uživatelem|Zrušeno - adminem|Zrušeno - uživatel již neexistuje|Zrušeno - vozidlo odstraněno|Zrušeno - vozidlo mimo provoz|Neproběhlo)$";
                        Regex regex = new Regex(patternRezervace);
                        if (regex.IsMatch(radkySouboru[i]) == false)
                        {
                            return false;
                        }
                        else
                        {
                            GroupCollection gc = regex.Match(radkySouboru[i]).Groups;
                            if (GeneratorID.ExistujeID(gc[1].ToString()))
                            {
                                MessageBox.Show("V souboru nalezeno duplictní rezervace ID: " + gc[1], "ERROR");
                                return false;
                            }

                            if (!(GeneratorID.ExistujeID(gc[2].Value) && GeneratorID.ExistujeID(gc[5].Value)))
                            {
                                MessageBox.Show("V souboru se vyskytuje rezervace vázaná na neexistující ID - rezervace: " + gc[1].Value, "ERROR");
                                return false;
                            }

                            DateTime casOd = DateTime.Parse(gc[3].Value);
                            DateTime casDo = DateTime.Parse(gc[4].Value);

                            if (casDo > casOd)
                            {
                                PromenneProVsechnyForms.RezervaceList.Add(new Rezervace(gc[1].Value, gc[2].Value, casOd, casDo, gc[5].Value, gc[6].Value));
                            }
                            else 
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else 
            {
                MessageBox.Show("Úvod+závěr", "ERROR");
                return false; 
            }

            return true;
        }

        private void LoadFromFile(string path, bool spoluSKontrolou) 
        {
            PromenneProVsechnyForms.UsersList.Clear();
            PromenneProVsechnyForms.RezervaceList.Clear();
            PromenneProVsechnyForms.AutaList.Clear();
            PromenneProVsechnyForms.NakladyList.Clear();

            string[] radkyFilu = File.ReadAllLines(path);
            if (spoluSKontrolou)
            {
                bool validitaSouboru = LoadVracejiciValiditu(radkyFilu);
                if (validitaSouboru == false)
                {
                    MessageBox.Show("Vybraný txt soubor neobsahuje databázovou strukturu UParkeru - operace zrušena", "ERROR");
                    return;
                }
                else
                {
                    //MessageBox.Show("Povedlo se!", "FILE LOADED"); //alert o úspěchu
                }
            }
            else
            {
                //Načte fixně default-info
                PromenneProVsechnyForms.UsersList.Add(new User("U1010AS", "Admin", "Adam", "Admin", "VBWyfB5VDCSei29dEF==", true, false, false));
                PromenneProVsechnyForms.pocetCiferVID = 6;
            }

            AktualizaceRezervaciADostupnosti();

            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void AktualizaceRezervaciADostupnosti() 
        {
            AktualizaceRezervaci();
            AktualizaceDostupnostiAut();
        }

        private void AktualizaceRezervaci() 
        {
            for(int i = 0; i < PromenneProVsechnyForms.RezervaceList.Count; i++) 
            {
                if(PromenneProVsechnyForms.RezervaceList[i].DatumACasDo <= DateTime.Now && PromenneProVsechnyForms.RezervaceList[i].Stav == "Neproběhlo") 
                {
                    PromenneProVsechnyForms.RezervaceList[i].NastavStav("Proběhlo");
                }
            }
        }

        private void AktualizaceDostupnostiAut() 
        {
            for (int i = 0; i < PromenneProVsechnyForms.AutaList.Count; i++)
            {
                if(PromenneProVsechnyForms.AutaList[i].Stav == "MP") 
                {
                    if(PromenneProVsechnyForms.AutaList[i].DoKdyNedostupne != "DoOdvolani" && PromenneProVsechnyForms.AutaList[i].DoKdyNedostupne != "Odstraneno") 
                    {
                        if(DateTime.Parse(PromenneProVsechnyForms.AutaList[i].DoKdyNedostupne) <= DateTime.Now) 
                        {
                            PromenneProVsechnyForms.AutaList[i].NastavitDostupnost();
                        }
                    }
                }
            }
        }

        private void Form0_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

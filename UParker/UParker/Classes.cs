using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UParker
{

    public static class PromenneProVsechnyForms
    {
        public static int pocetCiferVID;
        public static Random randomProgramu = new Random();

        private static List<User> userList = new List<User>();
        public static List<User> UsersList
        {
            set { userList = value; }
            get { return userList; }
        }


        private static List<Auto> autaList = new List<Auto>();
        public static List<Auto> AutaList
        {
            set { autaList = value; }
            get { return autaList; }
        }

        private static List<NakladyAuta> nakladyList = new List<NakladyAuta>();
        public static List<NakladyAuta> NakladyList
        {
            set { nakladyList = value; }
            get { return nakladyList; }
        }

        private static List<Rezervace> rezervaceList = new List<Rezervace>();
        public static List<Rezervace> RezervaceList
        {
            set { rezervaceList = value; }
            get { return rezervaceList; }
        }
    }

    public class User
    {
        public string UserID { set; get; }
        public string Username { set; get; }
        public string KrestniJmeno { set; get; }
        public string Prijmeni { set; get; }
        public string Heslo { set; get; }
        public DateTime LastLoginDatumACas { set; get; } //formát: dd.MM.yyyy HH:mm
        public bool JeAdmin { set; get; }
        public bool MaVynucenouZmenuHesla { set; get; }
        public bool ZrusenaUzivatelskaRezervaceOdPosledniNavstevy { set; get; }

        public User(string ID, string name, string krestni, string prijmeni, string zasifrovaneHeslo, DateTime casLoginu, bool jeAdmin, bool maVynucenouZmenuHesla, bool zrusenaRezervace)
        {
            UserID = ID;
            Username = name;
            KrestniJmeno = krestni;
            Prijmeni = prijmeni;
            Heslo = zasifrovaneHeslo;
            LastLoginDatumACas = casLoginu;
            JeAdmin = jeAdmin;
            MaVynucenouZmenuHesla = maVynucenouZmenuHesla;
            ZrusenaUzivatelskaRezervaceOdPosledniNavstevy = zrusenaRezervace;
        }

        public User(string ID, string name, string krestni, string prijmeni, string zasifrovaneHeslo, bool jeAdmin, bool maVynucenouZmenuHesla, bool zrusenaRezervace)
        {
            UserID = ID;
            Username = name;
            KrestniJmeno = krestni;
            Prijmeni = prijmeni;
            Heslo = zasifrovaneHeslo;
            LastLoginDatumACas = new DateTime();
            JeAdmin = jeAdmin;
            MaVynucenouZmenuHesla = maVynucenouZmenuHesla;
            ZrusenaUzivatelskaRezervaceOdPosledniNavstevy = zrusenaRezervace;
        }

        public void OdstranitZeSystemu()
        {
            int cisloGhostUsera = 0;
            foreach (User u in PromenneProVsechnyForms.UsersList)
            {
                if (u.Username.Contains("GhostUser") && u.Heslo == "")
                {
                    cisloGhostUsera++;
                }
            }

            foreach (Rezervace r in PromenneProVsechnyForms.RezervaceList)
            {
                if (r.IDUser == this.UserID)
                {
                    r.NastavStav("Zrušeno - uživatel již neexistuje");
                }
            }

            Username = "GhostUser" + cisloGhostUsera;
            Heslo = "";
            KrestniJmeno = "Odstraneny";
            Prijmeni = "Uzivatel";

        }

        public override string ToString()
        {
            if (LastLoginDatumACas == new DateTime())
            {
                string user = $"{UserID}|{Username}|{KrestniJmeno}|{Prijmeni}|{Heslo}||{JeAdmin.ToString()}|{MaVynucenouZmenuHesla.ToString()}|{ZrusenaUzivatelskaRezervaceOdPosledniNavstevy.ToString()}";
                return user;
            }
            else
            {
                string user = $"{UserID}|{Username}|{KrestniJmeno}|{Prijmeni}|{Heslo}|{LastLoginDatumACas.ToString("dd.MM.yyyy HH:mm")}|{JeAdmin.ToString()}|{MaVynucenouZmenuHesla.ToString()}|{ZrusenaUzivatelskaRezervaceOdPosledniNavstevy.ToString()}";
                return user;
            }
        }
    }

    public class Auto
    {
        public string AutoID { set; get; }
        public string Znacka { set; get; }
        public string Model { set; get; }
        public string Typ { set; get; }
        public double Spotreba { set; get; } //spotřeba na 100 km
        public string Stav { private set; get; }
        public string DoKdyNedostupne { private set; get; } //voleno string kvůli možnosti zadat "Nedostupné do odvolání"

        public List<NakladyAuta> NakladyTohotoAuta { set; get; }

        public void NastavitDostupnost()
        {
            this.Stav = "D";
            this.DoKdyNedostupne = "-";
        }

        public void NastavitNedostupnost()
        {
            this.Stav = "MP";
            this.DoKdyNedostupne = "DoOdvolani";
        }

        public void OdstranitZeSystemu()
        {
            this.Stav = "MP";
            this.DoKdyNedostupne = "Odstraneno";
        }

        public void NastavitNedostupnost(DateTime nedostupneDo)
        {
            this.Stav = "MP";
            this.DoKdyNedostupne = nedostupneDo.ToString("dd.MM.yyyy HH:mm");
        }


        public Auto(string ID, string znacka, string model, string typ, double spotreba, string stav, string doKdyNedostupne)
        {
            AutoID = ID;
            Znacka = znacka;
            Model = model;
            Typ = typ;
            Spotreba = spotreba;
            Stav = stav;
            DoKdyNedostupne = doKdyNedostupne;
            NakladyTohotoAuta = new List<NakladyAuta>();
        }

        public Auto(string ID, string znacka, string model, string typ, double spotreba, string stav, string doKdyNedostupne, List<NakladyAuta> nakladyAuta)
        {
            AutoID = ID;
            Znacka = znacka;
            Model = model;
            Typ = typ;
            Spotreba = spotreba;
            Stav = stav;
            DoKdyNedostupne = doKdyNedostupne;
            NakladyTohotoAuta = nakladyAuta;
        }

        public Auto()
        {
            //využito v auto-control formu: form 8
        }

        public bool JeDostupneVCas(DateTime odZacatku, DateTime doKonce)
        {
            if (Stav == "MP")
            {
                if (DoKdyNedostupne == "DoOdvolani" || DoKdyNedostupne == "Odstraneno")
                {
                    return false;
                }
                else
                {
                    DateTime nedostupneDo = DateTime.Parse(DoKdyNedostupne);
                    if (nedostupneDo > odZacatku)
                    {
                        return false;
                    }
                }
            }
            foreach (Rezervace r in PromenneProVsechnyForms.RezervaceList)
            {
                if (r.IDAuta == AutoID && r.Stav == "Neproběhlo")
                {
                    bool validniPred = doKonce < r.DatumACasOd;

                    bool validniPo = odZacatku > r.DatumACasDo;

                    if (!(validniPo || validniPred))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            string auto = $"{AutoID}|{Znacka}|{Model}|{Typ}|{Spotreba.ToString().Replace(',', '.')}|{Stav}|{DoKdyNedostupne}";
            return auto;
        }
    }

    public class NakladyAuta
    {
        public string CisloFaktury { set; get; } //jelikož číslo faktury nemusí být jen číselné, byl zvolen string
        public string AutoID { set; get; }
        public string PopisNakladu { set; get; }
        public DateTime DatumProbehnutiNakladu { set; get; }
        public TimeSpan CasovaNarocnost { set; get; }
        public decimal Cena { set; get; }

        public NakladyAuta(string cisloFaktury, string IDauta, string popisNakladu, DateTime datumNakladu, TimeSpan casovaNarocnost, decimal cena)
        {
            CisloFaktury = cisloFaktury;
            AutoID = IDauta;
            PopisNakladu = popisNakladu;
            DatumProbehnutiNakladu = datumNakladu;
            CasovaNarocnost = casovaNarocnost;
            Cena = cena;
        }

        public NakladyAuta(string cisloFaktury, string popisNakladu, DateTime datumNakladu, TimeSpan casovaNarocnost, decimal cena)
        {
            CisloFaktury = cisloFaktury;
            PopisNakladu = popisNakladu;
            DatumProbehnutiNakladu = datumNakladu;
            CasovaNarocnost = casovaNarocnost;
            Cena = cena;
        }

        public override string ToString()
        {
            string naklady = $"{CisloFaktury}|{AutoID}|{PopisNakladu}|{DatumProbehnutiNakladu.ToString("dd.MM.yyyy HH:mm")}|{CasovaNarocnost.ToString()}|{Cena.ToString().Replace(',', '.')}";
            return naklady;
        }
    }

    public class Rezervace
    {
        public string IDRezervace { set; get; }
        public string IDUser { set; get; }
        public DateTime DatumACasOd { set; get; }
        public DateTime DatumACasDo { set; get; }
        public string IDAuta { set; get; }
        public string Stav { private set; get; }

        public void NastavStav(string stav)
        {
            string[] validniStavy = { "Proběhlo", "Zrušeno - uživatelem", "Zrušeno - adminem", "Zrušeno - uživatel již neexistuje", "Zrušeno - vozidlo odstraněno", "Zrušeno - vozidlo mimo provoz", "Neproběhlo" };

            if (validniStavy.Contains(stav))
            {
                Stav = stav;
            }
        }


        public Rezervace(string rezervaceID, string userID, DateTime rezervaceOd, DateTime rezervaceDo, string autoID)
        {
            IDRezervace = rezervaceID;
            IDUser = userID;
            DatumACasOd = rezervaceOd;
            DatumACasDo = rezervaceDo;
            IDAuta = autoID;

            Stav = "Neproběhlo";
        }

        public Rezervace(string rezervaceID, string userID, DateTime rezervaceOd, DateTime rezervaceDo, string autoID, string stav)
        {
            IDRezervace = rezervaceID;
            IDUser = userID;
            DatumACasOd = rezervaceOd;
            DatumACasDo = rezervaceDo;
            IDAuta = autoID;
            Stav = stav;
        }

        public override string ToString()
        {
            string rezervace = $"{IDRezervace}|{IDUser}|{DatumACasOd.ToString("dd.MM.yyyy HH:mm")}|{DatumACasDo.ToString("dd.MM.yyyy HH:mm")}|{IDAuta}|{Stav}";
            return rezervace;
        }
    }


    public class SifrovaniHesla
    {
        /*
        Tato třída obsahuje metody sloužící pro zašifrování hesla.
         */

        public static string Sifruj(string username, string heslo)
        {
            string malaAbeceda = "abcdefghijklmnopqrstuvwxyz";
            string velkaAbeceda = malaAbeceda.ToUpper();

            var BytesNaSifrovani = System.Text.Encoding.UTF8.GetBytes(heslo);
            string zasifrovanoB64 = Convert.ToBase64String(BytesNaSifrovani);

            string finalniSifra = CaesarovaSifruj(zasifrovanoB64, username.Length, malaAbeceda, velkaAbeceda);

            return finalniSifra;
        }

        static string CaesarovaSifruj(string zasifrovano, int posun, string malaAbeceda, string velkaAbeceda)
        {
            StringBuilder SB = new StringBuilder(zasifrovano.Length);
            for (int i = 0; i < zasifrovano.Length; i++)
            {
                if (malaAbeceda.Contains(zasifrovano[i]))
                {
                    SB.Append(SifrovaniZnaku(zasifrovano[i], posun, malaAbeceda));
                }
                else
                {
                    if (velkaAbeceda.Contains(zasifrovano[i]))
                    {
                        SB.Append(SifrovaniZnaku(zasifrovano[i], posun, velkaAbeceda));
                    }
                    else
                    {
                        SB.Append(zasifrovano[i]);
                    }
                }
            }
            return SB.ToString();
        }

        static char SifrovaniZnaku(char charPuvod, int posun, string abeceda)
        {
            int finalChar = abeceda.IndexOf(charPuvod) + posun;

            bool finalCharJeZapor = finalChar < 0;
            finalChar %= abeceda.Length;

            if (finalCharJeZapor)
            {
                finalChar += abeceda.Length;
            }

            return abeceda[finalChar];
        }
    }

    public class GeneratorID
    {
        /*
        Tato třída obsahuje metody sloužící pro generace unikátních ID a jejich kontrolu
         */

        static string GenerujXCifernaCisla(int pocetCifer)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pocetCifer; i++)
            {
                sb.Append(PromenneProVsechnyForms.randomProgramu.Next(0, 10));
            }

            return sb.ToString();
        }

        static string GenerujDvePismena()
        {
            string abeceda = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();

            sb.Append(abeceda[PromenneProVsechnyForms.randomProgramu.Next(0, 26)]);
            sb.Append(abeceda[PromenneProVsechnyForms.randomProgramu.Next(0, 26)]);

            return sb.ToString();
        }

        public static string VygenerujUserID()
        {
            StringBuilder sb = new StringBuilder(32);
            int pocetProjeti = 0;
            double maxMoznostiCiselVID = 26 * 26 * Math.Pow(10, PromenneProVsechnyForms.pocetCiferVID - 2);

            do
            {
                if (pocetProjeti > maxMoznostiCiselVID)
                {
                    PromenneProVsechnyForms.pocetCiferVID++;
                    pocetProjeti = 0;
                }

                sb.Clear();
                sb.Append("U");
                sb.Append(GenerujXCifernaCisla(PromenneProVsechnyForms.pocetCiferVID - 2));
                sb.Append(GenerujDvePismena());
                pocetProjeti++;
            } while (!JeVolneUserID(sb.ToString()));


            return sb.ToString();
        }

        public static string VygenerujAutoID()
        {
            StringBuilder sb = new StringBuilder(32);
            int pocetProjeti = 0;
            double maxMoznostiCiselVID = 26 * 26 * Math.Pow(10, PromenneProVsechnyForms.pocetCiferVID - 1);

            do
            {
                if (pocetProjeti > maxMoznostiCiselVID)
                {
                    PromenneProVsechnyForms.pocetCiferVID++;
                    pocetProjeti = 0;
                }

                sb.Clear();
                sb.Append("A");
                sb.Append(GenerujXCifernaCisla(PromenneProVsechnyForms.pocetCiferVID - 1));
                sb.Append(GenerujDvePismena());
                pocetProjeti++;
            } while (!JeVolneAutoID(sb.ToString()));


            return sb.ToString();
        }

        public static string VygenerujRezervaceID()
        {
            StringBuilder sb = new StringBuilder(32);
            int pocetProjeti = 0;
            double maxMoznostiCiselVID = Math.Pow(10, PromenneProVsechnyForms.pocetCiferVID + 2);

            do
            {
                if (pocetProjeti > maxMoznostiCiselVID)
                {
                    PromenneProVsechnyForms.pocetCiferVID++;
                    pocetProjeti = 0;
                }

                sb.Clear();
                sb.Append("R");
                sb.Append(GenerujXCifernaCisla(PromenneProVsechnyForms.pocetCiferVID + 2));
                pocetProjeti++;
            } while (!JeVolneRezervaceID(sb.ToString()));


            return sb.ToString();
        }

        public static bool ExistujeID(string id)
        {
            //dle začátku ID pozná o jaké ID se jedná a dle toho bude hledat
            if (id[0] == 'R')
            {
                return !JeVolneRezervaceID(id);
            }
            else
            {
                if (id[0] == 'A')
                {
                    return !JeVolneAutoID(id);
                }
                else
                {
                    if (id[0] == 'U')
                    {
                        return !JeVolneUserID(id);
                    }
                }
            }
            throw new ArgumentException("Vyskytlo se ID, které není validní - program ukončen");
        }

        static bool JeVolneUserID(string id)
        {
            foreach (User u in PromenneProVsechnyForms.UsersList)
            {
                if (u.UserID == id) { return false; }
            }
            return true;
        }

        static bool JeVolneAutoID(string id)
        {
            foreach (Auto a in PromenneProVsechnyForms.AutaList)
            {
                if (a.AutoID == id) { return false; }
            }
            return true;
        }


        static bool JeVolneRezervaceID(string id)
        {
            foreach (Rezervace r in PromenneProVsechnyForms.RezervaceList)
            {
                if (r.IDRezervace == id) { return false; }
            }
            return true;
        }
    }

    public class UlozDoSouboru
    {
        public static void UlozVseDoTxtSouboru()
        {
            OpenFileDialog vyberFileDialog = new OpenFileDialog();
            DialogResult dR;
            do
            {
                dR = vyberFileDialog.ShowDialog();
                if(dR != DialogResult.OK) 
                {
                    MessageBox.Show("Zvolte nějaký soubor pro uložení databáze - bez tohoto neukončíte aplikaci!", "ERROR");
                }
            } while (dR != DialogResult.OK);
            string path = vyberFileDialog.FileName;
            int minimumSeznamu = PromenneProVsechnyForms.AutaList.Count + PromenneProVsechnyForms.UsersList.Count + PromenneProVsechnyForms.RezervaceList.Count + PromenneProVsechnyForms.NakladyList.Count + 11;
            
            List<string> seznamRadku = new List<string>(minimumSeznamu);
            seznamRadku.Add("UParker.txt");
            seznamRadku.Add("");
            seznamRadku.Add("Users:");
            //načte user
            foreach(User u in PromenneProVsechnyForms.UsersList) 
            {
                seznamRadku.Add(u.ToString());
            }
            
            seznamRadku.Add("");
            seznamRadku.Add("Auta:");
            //načte auta
            foreach (Auto a in PromenneProVsechnyForms.AutaList)
            {
                seznamRadku.Add(a.ToString());
            }

            seznamRadku.Add("");
            seznamRadku.Add("Naklady:");
            //načte náklady
            foreach (NakladyAuta nA in PromenneProVsechnyForms.NakladyList)
            {
                seznamRadku.Add(nA.ToString());
            }

            seznamRadku.Add("");
            seznamRadku.Add("Rezervace:");
            //načte rezervace
            foreach (Rezervace r in PromenneProVsechnyForms.RezervaceList)
            {
                seznamRadku.Add(r.ToString());
            }

            seznamRadku.Add("");

            string[] poleRadku = seznamRadku.ToArray();
            File.WriteAllLines(path, poleRadku);
        }
    }

    public class KontrolaTextVstupu 
    {
        public static bool KontrolaUsernameANazvuAut(string textNaKontrolu) 
        {
            //Username a auta mohou mít znaky české abecedy mezery, pomlčky a čísla
            string regexPattern = "^[a-zA-ZěščřžýáíéóúůďťňĎŇŤŠČŘŽÝÁÍÉÚŮ 0-9-]*$";
            Regex test = new Regex(regexPattern);
            return test.IsMatch(textNaKontrolu);
        }
        public static bool KontrolaJmen(string textNaKontrolu)
        {
            //jména mohou mít: pomlčky, mezery a znaky české abecedy
            string regexPattern = "^[a-zA-ZěščřžýáíéóúůďťňĎŇŤŠČŘŽÝÁÍÉÚŮ -]*$";
            Regex test = new Regex(regexPattern);
            return test.IsMatch(textNaKontrolu);
        }
        public static bool KontrolaVolnychVstupu(string textNaKontrolu)
        {
            //volné vstupy mohou obsahovat vše krom znaku |
            string regexPattern = "^[^\\|]*$";
            Regex test = new Regex(regexPattern);
            return test.IsMatch(textNaKontrolu);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasse_get_set
{
    class Person
    {
        // Variablen und Felder

        private string kennZeichen, vorName, nachName, ort, strasse, land, telefonNr, hausNummer;
        private int alter;


        public int Alter
        {
            get { return alter; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Das Alter darf nicht negativ sein.");
                }
                else alter = value;
            }
        }

        public string HausNummer
        {
            get { return hausNummer; }
            set { hausNummer = value; }
        }

        public string TelefonNr
        {
            get { return telefonNr; }
            set { telefonNr = value; }
        }

        public string KennZeichen
        {
            get { return kennZeichen; }
            set { kennZeichen = value; }
        }

        public string VorName
        {
            get { return vorName; }
            set { vorName = value; }
        }

        public string NachName
        {
            get { return nachName; }
            set { nachName = value; }
        }

        public string Ort
        {
            get { return ort; }
            set { ort = value; }
        }
        public string Strasse
        {
            get { return strasse; }
            set { strasse = value; }
        }

        public string Land
        {
            get { return land; }
            set { land = value; }
        }



        // Methoden

        public void HatGeburtstag()
        {
            alter = alter + 1;
            return;
        }

        // Eigene Konstruktoren

        public Person()
        {

        }

        public Person(string v_Name)
        {
            this.VorName = VorName;
        }

        public Person(string v_Name, string n_Name)
        {
            this.VorName = v_Name;
            this.NachName = n_Name;
        }

        public Person(string v_Name, string n_Name, int alt_alter)
        {
            this.VorName = v_Name;
            this.NachName = n_Name;
            this.Alter = alt_alter;
        }

        public Person(string v_Name, string n_Name, int alter, string adresse, string hausNummer, string ort, string land, string telefonNummer, string kennZeichen)
        {
            this.VorName = v_Name;
            this.NachName = n_Name;
            this.Alter = alter;
            this.Strasse = adresse;
            this.HausNummer = hausNummer;
            this.Ort = ort;
            this.Land = land;
            this.TelefonNr = telefonNr;
            this.KennZeichen = kennZeichen;
        }
        //Eigener Destruktor

        ~Person()
        {

        }


    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Klasse_get_set
{
    class Program
    {
        static int maxArray = 10;
        static Person[] liste = new Person[maxArray];
        static int countPersonen = 0;

        static string path = @"c:\test\PersonenListenText.csv";
        static string trennZeichen = ";";

        static void Main(string[] args)
        {
            do
            {
                switch (ZeigeMenu())
                {
                    case "1":
                        EingabePerson();
                        break;
                    case "2":
                        ZeigePersonenListe();
                        break;
                    case "3":
                        FeiereGeburtstag();
                        break;
                    case "4":
                        FuegePersonHinzu();
                        break;
                    case "5":
                        ReadCsv();
                        break;
                    case "6":
                        WriteCsv();
                        break;
                    case "7":
                        return;
                    default:
                        break;
                }
            } while (true);

        }

        static string ZeigeMenu()
        {
            string select;
            do
            {
                Console.Clear();
                Console.WriteLine("Wählen sie aus: ");
                Console.WriteLine("1) Person Hinzufügen");
                Console.WriteLine("2) Zeige personliste");
                Console.WriteLine("3) Person hat Geburtstag");
                Console.WriteLine("4) Person Hinzufügen (Parameter).");
                Console.WriteLine("5) Datenbank Laden");
                Console.WriteLine("6) Datenbank Speichern\n");
                Console.WriteLine("7) Programm Beenden.");
                Console.WriteLine("Wählen sie aus (1-7)");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                        return select;
                    default:
                        break;
                }
            } while (true);

        }

        static void EingabePerson()
        {
            if (countPersonen < maxArray)
            {
                Person temp = new Person();
                Console.Clear();
                Console.WriteLine("Bitte geben sie den Vornamen ein: ");
                temp.VorName = Console.ReadLine();
                Console.WriteLine("Bitte geben sie den Nachnamen ein: ");
                temp.NachName = Console.ReadLine();
                Console.WriteLine("Bitte geben sie das Alter ein: ");
                temp.Alter = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Bitte geben die die Strasse ein: ");
                temp.Strasse = Console.ReadLine();
                Console.WriteLine("Bitte geben sie die Hausnummer ein: ");
                temp.HausNummer = Console.ReadLine();
                Console.WriteLine("Bitte geben sie die PLZ ein: ");
                temp.Ort = Console.ReadLine();
                Console.WriteLine("Bitte geben sie das Bundesland ein: ");
                temp.Land = Console.ReadLine();
                Console.WriteLine("Bitte geben sie die Telefonnummer ein: ");
                temp.TelefonNr = Console.ReadLine();
                Console.WriteLine("Bitte geben sie das Kennzeichen ein: ");
                temp.KennZeichen = Console.ReadLine();
                liste[countPersonen++] = temp;
            }
            else
            {
                Console.WriteLine("Die Personen Liste ist bereits voll!");
                Console.WriteLine("Press Enter");
                Console.ReadLine();
                return;
            }
        }

        static void FeiereGeburtstag()
        {
            int var;

            if (countPersonen > 0)
            {
                //ZeigePersonenListe();
                Console.Clear();
                Console.WriteLine("###***Yay!!! Party Time! Geburtstags Party!***###");
                for (int zp = 0; zp < countPersonen; zp++)
                {
                    Console.WriteLine("Nr{0}. {1} {2}, Alter {3} Jahre", zp + 1, liste[zp].VorName, liste[zp].NachName, liste[zp].Alter);
                }
                Console.WriteLine("Wer hat geburtstag (1-{0}) ?", countPersonen);
                var = (Int32.Parse(Console.ReadLine()) - 1);
                liste[var].HatGeburtstag();
                Console.WriteLine("Happy Birthday {0} {1} !!! ;)\n{0} ist nun {2} Jahre geworden.", liste[var].VorName, liste[var].NachName, liste[var].Alter);
            }
            else Console.WriteLine("Datenbank ist noch leer !");

            Console.WriteLine("Press Enter");
            Console.ReadLine();
            return;
        }

        static void ZeigePersonenListe()
        {
            Console.Clear();
            Console.WriteLine("*Personen Liste*");
            if (countPersonen > 0)
            {
                for (int zp = 0; zp < countPersonen; zp++)
                {
                    Console.WriteLine("Eintrag Nr {9}:\n{0} {1} ist {2} Jahre alt.\nDie Adresse lautet:" +
                        " {3} {4} in {5} {6}.\nDie Rufnummer lautet: {7}. Und sein Kennzeichen ist {8}.\n"
                        , liste[zp].VorName, liste[zp].NachName, liste[zp].Alter, liste[zp].Strasse, liste[zp].HausNummer,
                        liste[zp].Ort, liste[zp].Land, liste[zp].TelefonNr, liste[zp].KennZeichen, zp + 1);
                }
            }
            else Console.WriteLine("Datenbank ist noch leer !");
            Console.WriteLine("Press Enter");
            Console.ReadLine();
            return;
        }

        static void FuegePersonHinzu()
        {
            string v_Name, n_Name;
            int alter;
            Console.WriteLine("***Fuege Neue Person Mit Atributen hinzu.\nGeben sie sie den Vornamen, Nachnamen und alter an:");
            Console.WriteLine("Geben sie den Vornamen ein:");
            v_Name = Console.ReadLine();
            Console.WriteLine("Geben sie den Nachnamen ein:");
            n_Name = Console.ReadLine();
            Console.WriteLine("Geben sie den Alter ein:");
            alter = Int32.Parse(Console.ReadLine());

            Person tempPerson = new Person(v_Name, n_Name, alter);
            liste[countPersonen++] = tempPerson;
            Console.WriteLine("Person hinzugefügt als liste[{0}]", countPersonen + 1);

        }

        static void WriteCsv()
        {
            string[] content = new string[9];
            for (int wi = 0; wi < countPersonen; wi++)
            {
                content[wi] = liste[wi].VorName + trennZeichen + liste[wi].NachName + trennZeichen + liste[wi].Alter + trennZeichen + liste[wi].Strasse +
                   trennZeichen + liste[wi].HausNummer + trennZeichen + liste[wi].Ort + trennZeichen + liste[wi].Land +
                    trennZeichen + liste[wi].TelefonNr + trennZeichen + liste[wi].KennZeichen;
            }
            try
            {
                File.WriteAllLines(path, content);
            }
            catch (Exception)
            {

                throw;
            }



        }

        static void ReadCsv()
        {
            string[] content;
            string[] temp;
            try
            {
                content = File.ReadAllLines(path);
            }
            catch (Exception)
            {

                throw;
            }

            liste = new Person[content.Length];
            for (int ri = 0; ri < content.Length; ri++) // Error: out of Array
            {
                temp = content[ri].Split(Convert.ToChar(trennZeichen));
                liste[ri] = new Person(temp[0], temp[1], Convert.ToInt32(temp[2]), temp[3], temp[4], temp[5], temp[6], temp[7], temp[8]);

            }
            countPersonen = content.Length;
        }

    }
}



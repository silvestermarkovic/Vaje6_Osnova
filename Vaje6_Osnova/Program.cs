using System;
using System.Linq;

namespace Vaje6_Osnova
{
    class Program
    {
        static void Main(string[] args)
        {


            //Linq dodatni primeri
            //TODO 1 Ustvarite uporabniški vmesnik, ki bo izpisal, možnosti in čakal na izbirni znak.
            //po vnesenem znaku se bo izvdela izbrana možnost, potem se ponovno izpiše osnovni menu
            //Izgled osnovnega menija.
            //Vnesite znak, katero nalogo želite izpisati:
            //NalogaA
            //NalogaB
            //NalogaC
            //NalogaD
            //NalogaE 
            //Izhod: X
            while (true)
            {
                Console.WriteLine("Vnesite znak, katero nalogo želite izpisati:");
                Console.WriteLine("NalogaA");
                Console.WriteLine("NalogaB");
                Console.WriteLine("NalogaC");
                Console.WriteLine("NalogaD");
                Console.WriteLine("NalogaE");
                Console.WriteLine("Izhod: X");
                char ukaz = Console.ReadKey().KeyChar;
                switch (ukaz.ToString().ToUpper())
                {
                    case "A":

                        //NALOGA A

                        //TODO 1A
                        var nalogaA = new[] { 3, 9, 2, 8, 6, 5 };
                        Console.Write("\nLINQ : Najdite in izpišite števila, katerih kvadrat je več kot 20: ");
                        Console.Write("\n------------------------------------------------------------------------\n");

                        //Linq koda, ki vrne števila in kvadrat, podanih števil (kjer je kvadrat podanih števil večji od 20)
                        var poizA = from int stev in nalogaA
                                    let kvadrat = stev * stev //let dodamo novo polje, ki ga lahko uporabljamo naprej
                                    where kvadrat > 20
                                    select new
                                    {
                                        stev,
                                        kvadrat
                                    };

                        //Izpišite, kvadrat števil iz seznama
                        foreach (var a in poizA)
                            Console.WriteLine(a);
                        Console.ReadLine();
                        //*/
                        break;
                    case "B":

                        //NALOGA B
                        //TODO 1B
                        int[] nalogaB = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

                        Console.Write("\nLINQ : Izpišite števila, ki so pozitivna (>0) in manjša (<) od 12: ");
                        Console.Write("\n-----------------------------------------------------------------------------");


                        //Linq koda
                        var poizB = from stev in nalogaB
                                    where stev > 0 && stev < 12
                                    select stev;
                        //izpis števil
                        Console.Write("\nŠtevila med 1 in 11 so: \n");
                        //koda za izpis
                        foreach(var st in poizB)
                            Console.WriteLine(st);
                        Console.ReadLine();

                        break;
                    case "C":
                        //*/
                        //TODO 1C
                        // NALOGA C

                        //iz podanega seznama, izpišite za posamezno število, kolikokrat se ponovi
                        int[] nalogaC = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
                        Console.Write("\nLINQ : Izpišite število in število ponovitev posameznega števila, v podanem seznamu: \n");
                        Console.Write("---------------------------------------------------------------------\n");
                        Console.Write("Števila v seznamu so: \n");
                        //TODO 1C izpišite števila v eni vrstici
                        // izpište naj se 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2


                        //LINQ koda
                        var poizC = from st in nalogaC
                                    group st by st into rez
                                    orderby rez.Count() descending  //v rez se nahajo podatki grupe (za vsak rez.key so zapisi), na katerih lahko uporabimo metode sum/average/count...
                                    select rez;
                        Console.WriteLine("\nŠtevka, število ponovitev: \n");
                                               
                        foreach (var st in poizC)
                        {
                            Console.WriteLine("Število " + st.Key + " se pojavi " + st.Count() + " krat");
                        }
                        //Pomoč: Console.WriteLine("Število " + arrNo.Key + " se pojavi " + arrNo.Count() + " krat");



                            Console.ReadLine();
                        //*/

                        break;
                    case "D":
                        //NALOGA D
                        //TODO 1D  Najdite mesta, ki se začnejo in končajo z določenim znakom.

                        string chzacetek, chkonec;
                        char ch;
                        string[] mesta =
                        {
                            "RIM","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS", "LJUBLJANA", "DUNAJ", "PARIS", "ZAGREB"
                        };

                        Console.Write("\nLINQ : Najdite mesta, ki se začnejo in končajo z določenim znakom: ");
                        Console.Write("\n-----------------------------------------------------------------------\n");

                        //TODO 1D Izpišite mesta v 1 vrstici:
                        //Mesta so: RIM, .....
                        //koda


                        //preberite vnos prvi znak chzacetek
                        //pomoc ReadKey().KeyChar
                        Console.WriteLine("Vnesite znak, s katerim znakom naj se začne naziv mesta: ");
                        ch = Console.ReadKey().KeyChar;
                        chzacetek = ch.ToString();

                        //preberite vnos zadnji znak chkonec
                        Console.WriteLine("\nVnesite znak, s katerim znakom naj se konča naziv mesta: ");
                        ch = Console.ReadKey().KeyChar;
                        chkonec = ch.ToString();

                        //Linq poizvedba  (imate metodo, ki to dela startswith....)
                        var _poizvedba = from x in mesta
                                         where x.StartsWith(chzacetek)
                                         where x.EndsWith(chkonec)
                                         select x;

                        //koda za izpis mest
                        //za vsako izpišite: "Mesto se začne z znakom {0} in konča z znakom {1} je : {2}"
                        foreach (var mesto in _poizvedba)
                        {
                            Console.WriteLine("\nMesto se začne z znakom {0} in konča z znakom {1} je : {2}", chzacetek, chkonec, mesto);
                        }
                       
                       

                        Console.ReadLine();

                        //*/
                        break;
                    case "E":

                        //NALOGA E  (kartezični produkt)
                        //TODO 1E
                        //kartezični produkt, so vse možnosti med emelenti obeh seznamov
                        //izpišite kartezični produkt podanih seznamov
                        char[] sezznakiE = { 'X', 'Y', 'Z' };
                        int[] sezstevilaE = { 1, 2, 3, 4 };

                        Console.Write("\nKartezični produkt seznamov je: ");
                        Console.Write("\n------------------------------------------------\n");


                        //linq
                        //var kartezicniProdukt 
                        var kartezicniProdukt = from znakiE in sezznakiE
                                                from stevilaE in sezstevilaE
                                                select new { znakiE, stevilaE };

                        Console.WriteLine("Kartezični produkt: \n");
                        //koda izpis elementov 
                        foreach (var productItem in kartezicniProdukt)
                        {
                            Console.WriteLine(productItem);
                        }
                        Console.WriteLine("Kartezični produkt: \n");
                        //koda izpis elementov 
                        foreach (var productItem in kartezicniProdukt)
                        {
                            Console.WriteLine(productItem);
                        }
                        Console.ReadLine();

                        //dodatni razmislek:
                        //kako bi to uporabili pri premiku kraljice, če je na polju (2,3)

                        //*/

                        //X izhod iz programa   Environment.Exit (0);
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Napačen ukaz!\n\n\n");
                        break;
                }
            }
        }
    }
}

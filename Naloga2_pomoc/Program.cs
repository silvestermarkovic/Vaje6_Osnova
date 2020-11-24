using System;
using System.Threading;
using System.Timers;

namespace Naloga2_pomoc
{
    class Program
    {
        static string stateObject1 = "AAAAA";

        //primer1
        static System.Threading.Timer tim1;


        static void Main(string[] args)
        {




            //TODO 3 Primer deklariranja Therading objekta 1. način
            // https://www.c-sharpcorner.com/UploadFile/1d42da/timer-class-in-threading-C-Sharp/
            tim1 = new System.Threading.Timer(TimerPovratniKlic, "sssssss", 1000, 1000);



            //TODO 3 Primer deklariranja Therading objekta 2. način, iz vaj
            string stateObject = "BBBBB";
            var timer = new System.Threading.Timer(
                  state => {
                      Console.WriteLine($"Uporabnik {state} kliče kodo v timerju!"); // Dejanska koda, ki se izvede
                  },
                  stateObject, // Objekt, ki ga uporabimo v spremenljivki state v zgornjem lambda izrazu
                  1000,   // Zamik pred prvim klicem timerja
                  2000    // Interval med zaporednimi klici. V tem primeru naslednjega klica ne bo.
                  );

            Console.ReadLine();
            Console.WriteLine("Konec Timer1");

            timer.Dispose();
            tim1.Dispose();


            //TODO 3: primer Timers.Timer
            Console.WriteLine("Timer2");
            var casovnik = new System.Timers.Timer();
            casovnik.Interval = 2000;
            casovnik.Elapsed += dogodek;
            casovnik.AutoReset = true;
            casovnik.Start();

            Console.ReadLine();
            Console.WriteLine("Konec Timer2");

        }

        public static void dogodek(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Uporabnik {stateObject1} kliče kodo v timerju!");
        }


        private static void TimerPovratniKlic(object podatek)
        {
            Console.WriteLine($"Tim1 {podatek} kliče kodo v timerju!");
        }
    }
}

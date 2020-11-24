using System;
using System.Threading;
using System.Timers;

namespace Naloga2_pomoc
{
    class Program
    {
        static string stateObject1 = "AAAAA";

        //primer1
        static System.Threading.Timer timerDrugiNacin;


        static void Main(string[] args)
        {


            /*

            //TODO 3 Primer deklariranja Therading objekta 1. način
            // https://www.c-sharpcorner.com/UploadFile/1d42da/timer-class-in-threading-C-Sharp/

           

            //TODO 3 Primer deklariranja Therading objekta 2. način, iz vaj
            string stateObject = "BBBBB";
            var timer = new System.Threading.Timer(
                  x => {
                      Console.WriteLine($"TIMER: Vhodni parameter {x} !"); // Dejanska koda, ki se izvede
                  },
                  stateObject, // Objekt, ki ga uporabimo v spremenljivki state v zgornjem lambda izrazu
                  6000,   // Zamik pred prvim klicem timerja
                  500    // Interval med zaporednimi klici. V tem primeru naslednjega klica ne bo.
                  );

          
            timerDrugiNacin = new System.Threading.Timer(TimerPovratniKlic, stateObject,  0, 700);


            Console.WriteLine("Konec Timer1");

            timer.Dispose();
            timerDrugiNacin.Dispose();
            */

            //TODO 3: primer Timers.Timer
            Console.WriteLine("Timer2");
            var casovnik = new System.Timers.Timer();
            casovnik.Interval = 2000;
            casovnik.Elapsed += dogodek;
            casovnik.AutoReset = true;
            casovnik.Start();

            Console.ReadLine();
            stateObject1 = "kkkkkk";

            Console.WriteLine("Konec Timer2");

        }

        public static void dogodek(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Uporabnik {stateObject1} kliče kodo v timerju!");
        }


        private static void TimerPovratniKlic(object podatek)
        {
            Console.WriteLine($"TimerDrugiNačin {podatek} kliče kodo v timerju!");
        }
    }
}

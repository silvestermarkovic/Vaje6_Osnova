using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Naloga2
{
    class Program
    {
        //TODO 2.1 deklarirajte spremenljivko z imenom casovnik, tipa System.Timers.Timer, ki se bo izvedla vsakih 3s
        //private, static
        private static System.Timers.Timer casovnik = new System.Timers.Timer(3000);

        static void Main(string[] args)
        {
            Random _random = new Random();

            // Razporejevalniku bomo ustvarili naloge, z različnim časom in obremenitvijo
            var razporediteljbremena = Razporeditelj.VrniRazporeditelj();



            //TODO 2.3
            //klicite metodo dolociCasovnik, ki kot parameter dobi casovnik ustvarjen v koraku 2.1
            //koda 1 vrstica

            

            //vaša koda
            //uporabnik vnese koliko obremenitev naj se utvari
            //namesto 100 dajte vneseno vrednost

            for (int i = 0; i < 100; i++)
            {
                int teza = _random.Next(10, 30);
                //zaženemo Task in nadaljujemo
                Task<int> naloga = ObremenitevAsync(_random.Next(2, 6), razporediteljbremena.NaslednjiStreznik(teza), teza);
            }


            
            // Počakamo pred koncem
            Console.ReadKey();
        }



        //VAJE 6
        private static void dolociCasovnik(System.Timers.Timer pcasovnik)
        {

            //TODO 2.4
            // Časovniku določite interval 2s (kličite konstuktor  System.Timers.Timer) 
            //določite interval na 2s
            
            // na event Elapsed, dodajte metodo casovnikDogodek 

            //časovnik naj deluje ves čas, naj se izvaja nepreklicno
            //koda 1 vrstica
            
            //vkjucite/zaženite pcasovnik
            //koda 1 vrstica
            
        }
        //VAJE 6
        private static void casovnikDogodek(Object source, ElapsedEventArgs e)
        {
            //INFO čas klica 
            //Console.WriteLine("Dogodek je bil sprožen {0:HH:mm:ss.fff}", e.SignalTime);

            //TODO 2.5
            //uporabite razred singleton in izpišite trenutno stanje strežnikov
            //deklarijate spremenljivko tipa Razporeditelj s klicem Razporeditelj.VrniRazporeditelj
            
            //kličite izpis stanja, ki ste ga kreirali v točki 2.2
            



        }



        //VAJE 4,5
        //metoda nam bo obremenila strezik za dolocsen cas
        //metoda ja async (več je predvideno v nadaljevanju)
        public static async Task<int> ObremenitevAsync(double cas, Streznik pstreznik, int pteza)
        {
            //povečamo StKlicev
            pstreznik.StKlicev += 1;
            //dodamo obremenitev
            pstreznik.Obremenitev += pteza;

            //zapisemo si trenutno stevilo klicev (ker sicer bi pstreznik vrnil trenutno)
            int temp = pstreznik.StKlicev;

            // Console.WriteLine("Zacetek (" + temp + "/" + pstreznik.StKlicev + "): " + pstreznik.Name + " Cas: " + cas + "s  Zahtevnost:" + pteza + " " + pstreznik.Obremenitev + "/" + pstreznik.ObremenitevMax);

            //podatki moramo v milisekundah zato * 1000            
            int sek = (int)cas * 1000;
            //await pove, da async počaka, da se izvrši ukaz, sicer bi nadaljevalo takoj
            await Task.Delay(sek);
            //odstranimo obremenitev
            pstreznik.Obremenitev -= pteza;
            // Console.WriteLine("Konec (" + temp + "/" + pstreznik.StKlicev + "): " + pstreznik.Name + " Cas: " + cas + "s  Zahtevnost:" + pteza + " " + pstreznik.Obremenitev + "/" + pstreznik.ObremenitevMax);

            return 0;
        }
        public static void Obremenitev(double cas, Streznik pstreznik, int pteza)
        {
            //povečamo StKlicev
            pstreznik.StKlicev += 1;
            //dodamo obremenitev
            pstreznik.Obremenitev += pteza;

            //zapisemo si trenutno stevilo klicev (ker sicer bi pstreznik vrnil trenutno)
            int temp = pstreznik.StKlicev;

            Console.WriteLine("Zacetek (" + temp + "/" + pstreznik.StKlicev + "): " + pstreznik.Name + " Cas: " + cas + "s  Zahtevnost:" + pteza + " " + pstreznik.Obremenitev + "/" + pstreznik.ObremenitevMax);

            //podatki moramo v milisekundah zato * 1000            
            int sek = (int)cas * 1000;
            //await pove, da async počaka, da se izvrši ukaz, sicer bi nadaljevalo takoj
            Thread.Sleep(sek);
            //odstranimo obremenitev
            pstreznik.Obremenitev -= pteza;
            Console.WriteLine("Konec (" + temp + "/" + pstreznik.StKlicev + "): " + pstreznik.Name + " Cas: " + cas + "s  Zahtevnost:" + pteza + " " + pstreznik.Obremenitev + "/" + pstreznik.ObremenitevMax);

        }
    }
}

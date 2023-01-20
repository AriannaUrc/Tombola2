using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombola
{
    using System;

    class Program
    {

        public static void Tabellone()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i * 10 + j + 1 < 11)
                    {
                        Console.Write((i * 10 + j + 1) + "   ");
                    }
                    else
                    {
                        Console.Write((i * 10 + j + 1) + "  ");
                    }
                }
                Console.WriteLine("");
            }
        }

        public static int[,] Cartella(int off)
        {
            int x, y;
            bool[] decina = new bool[9];
            Random rand = new Random();
            int[,] cart1 = new int[3, 5];

            

            for (int i = 0; i < 3; i++)
            {

                //stampa prima cartella
                for (int j = 0; j < 5; j++)
                {
                    cart1[i, j] = rand.Next(1, 91);

                    //controllo numeri della cartella n1
                    If (cart[i,j]==90)
                    {
                    while (decina[8] == true)
                    {
                        cart1[i, j] = rand.Next(1, 91);
                    }
                    if (decina[8] == false)
                    {
                        decina[8] = true;
                    }
                    }
                    else
                    {
                    while (decina[cart1[i, j] / 10] == true)
                    {
                        cart1[i, j] = rand.Next(1, 91);
                    }
                    if (decina[cart1[i, j] / 10] == false)
                    {
                        decina[cart1[i, j] / 10] = true;
                    }
                    }

                    x = XValue(cart1[i, j]);
                    y = off + i;

                    if (cart1[i, j] == 90)
                    {
                        x = 9 * 4;
                    }

                    Console.SetCursorPosition(x, y);
                    Console.Write(cart1[i, j]);
                }

                //reset bool decina a tutta falsa
                for (int k = 0; k < decina.Length; k++)
                {
                    decina[k] = false;
                }
            }
            return cart1;

        }


        public static int XValue(int num)
        {
            int x;
            x = num / 10 * 4;
            return x;
        }

        public static void Main(string[] args)
        {
            Console.Clear();
            int n, x, y, cr1 = 0, cr2 = 0;
            bool[] uscito = new bool[90];
            bool[] decina = new bool[10];
            int[,] cart1 = new int[3, 5];
            int[,] cart2 = new int[3, 5];
            Random rand = new Random();


            //scrittura tabellone
            Tabellone();


            Console.SetCursorPosition(16, 11);
            Console.WriteLine("Cartella n.1");

            Console.SetCursorPosition(16, 21);
            Console.WriteLine("Cartella n.2");

            //scrittura e estrazione caselle
            cart1 = Cartella(14);
            System.Threading.Thread.Sleep(500);
            cart2 = Cartella(24);


            Console.SetCursorPosition(45, 1);
            Console.Write("Num estratto: ");
            Console.ForegroundColor = ConsoleColor.Yellow;

            //estrazione numeri finchè una delle variabili che contano quanti numeri sono stati indovinati raggiunge 15, cioè il numeri di numeri per cartella
            while (cr1 != 15 & cr2 != 15)
            {


                n = rand.Next(1, 91);

                //controllo che il numero estratto non era già uscito

                while (uscito[n - 1] == true)
                {
                    n = rand.Next(1, 91);
                }
                if (uscito[n - 1] == false)
                {
                    uscito[n - 1] = true;
                }

                Console.SetCursorPosition(59, 1);
                Console.Write(n);

                //trova coordinate del numero nel tabellone
                x = (n % 10 - 1) * 4;
                y = n / 10;
                if (n % 10 == 0)
                {
                    y--;
                    x = 9 * 4;
                }

                Console.SetCursorPosition(x, y);
                Console.Write(n);

                //controllare se il numero estratto è presente nelle cartelle dei giocatori

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        //controllo per la cartella 1
                        if (cart1[i, j] == n)
                        {
                            //incremento variabile per i numeri indovinati n.1
                            cr1++;
                            x = XValue(cart1[i, j]);
                            y = 14 + i;
                            Console.SetCursorPosition(x, y);
                            Console.Write(n);

                        }

                        //controllo per la cartella 2
                        if (cart2[i, j] == n)
                        {
                            //incremento variabile per i numeri indovinati n.2
                            cr2++;
                            x = XValue(cart2[i, j]);
                            y = 24 + i;
                            Console.SetCursorPosition(x, y);
                            Console.Write(n);
                        }
                    }
                }

                //aspetta per 0.5 secondi prima di estrarre il prossimo numero
                System.Threading.Thread.Sleep(500);
            }

            Console.SetCursorPosition(50, 28);
            Console.ForegroundColor = ConsoleColor.Blue;

            //controllo quale cartella ha il contatore == a 15 e scrivo che la corrispondente cartella ha vinto
            if (cr1 == 15)
            {
                Console.WriteLine("Tombola!! La cartella n.1 vince!");
            }

            if (cr2 == 15)
            {
                Console.WriteLine("Tombola!! La cartella n.2 vince!");
            }
        }
    }
}

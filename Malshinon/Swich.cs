using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class SwitchCoice
    {
        private SwitchCoice() { }
        public static void MenuChoice()
        {
            int Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
            }
        }
        public static int GetCoice(int Min,int Max)
        {
            int Coice = -1;
            bool goodChoice = false;
            int NumTry = 0;
            do
            {
                NumTry++;
                try
                {
                    Coice = Convert.ToInt32(ConsolePrint.Read());
                    if (Coice >= Min && Coice <= Max)
                        goodChoice = true;
                    else 
                    {
                        ConsolePrint.InputErorrs(4);
                        ConsolePrint.Maseg(4, $"{Min} and {Max}");
                    }
                }
                catch
                {
                    ConsolePrint.InputErorrs(3);
                    ConsolePrint.Maseg(4, $"{Min} and {Max}");
                }
            }
            while (!goodChoice&&NumTry <= 15);
            return Coice;
        }
    }
}

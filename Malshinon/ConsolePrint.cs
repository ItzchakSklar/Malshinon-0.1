using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class ConsolePrint
    {
        private ConsolePrint() { }
        public static void MenuStart()
        {
            Console.WriteLine("wellcome to malshinon enter your choice");
            Console.WriteLine("exit to exit");
        }
        public static void Maseg(int maseg = 0) 
        {
            switch (maseg)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Connection successful.");
                    break;
            }
        }
        public static void Maseg(string maseg = "samting")
        {
            Console.WriteLine(maseg);
        }
        public static void InputErorrs(int error = 0 , string Message = "")
        {
            switch (error)
            {
                case 0:
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine($"MySQL Error: {Message}");
                    break;
                case 2:
                    Console.WriteLine($"General Error: {Message}");
                    break;
            }
        }
        public static void Errors(int error = 0, string Massage = "")
        { 
            switch(error)
            {
                case 0:
                    Console.WriteLine($"a static error {Massage}");
                        break;
                case 1:
                    Console.WriteLine($"a problem to loud the first names of people {Massage}");
                    break;
                case 2:
                    Console.WriteLine($"a problem to loud SQL {Massage}");
                    break;
                case 3:
                    Console.WriteLine("To mach people to creat a new random");
                    break;
                case 4:
                    Console.WriteLine("something went wrong with loud a people to date byse");
                    break;
            }
        }
    }
}

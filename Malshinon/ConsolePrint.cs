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
        public static void Menulanch()
        {
            ConsolePrint.Clean();
            ConsolePrint.Maseg("Welcome to the system for report plies sing in or sing up");
            ConsolePrint.Maseg(2);
            ConsolePrint.Maseg("enter 1 to sing in\nenter 2 to sing up");
            ConsolePrint.Maseg(3);
        }
        public static void MenuStart()
        {
            Console.WriteLine("wellcome to malshinon enter your choice");
            Console.WriteLine("exit to exit");
        }
        public static void Maseg(int maseg = 0, string msg= "") 
        {
            switch (maseg)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Connection successful.");
                    break;
                case 2:
                    Console.WriteLine("You have diffrend options:");
                    break;
                case 3:
                    Console.WriteLine("pleas enter your chich:");
                    break;
                case 4:
                    Console.WriteLine("pleas try again betwin "+msg);
                    break;
                case 5:
                    Console.WriteLine();
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
                case 3:
                    Console.WriteLine("Not a good format of choice");
                    break;
                case 4:
                    Console.WriteLine("The coice out of range");
                    break;
            }
        }
        public static void InputErorrs(string Message = "")
        {
            Console.WriteLine(Message);
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
        public static string Read()
        {
            return Console.ReadLine();
        }
        public static void Clean() { Console.Clear(); }
    }
}

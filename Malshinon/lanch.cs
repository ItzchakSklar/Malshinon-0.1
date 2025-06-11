using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class lanch
    {
        
        private lanch() { }
        public static bool StartLanch(int sing)
        {
            Date Data = Date.GetInstans();
            Factory factory = Factory.getInstance();
            string fullname;
            string[] Namesplit = new string[2];
            string pasorrd = "";
            int TryName = 0;
            int Thryp = 0;
            if (sing == 1)
            {
                bool goodname = false;
                List<string> listNames = Data.getFullName();
                do
                {
                    TryName++;
                    pasorrd = "";
                    ConsolePrint.Maseg("enter your full name");
                    fullname = ConsolePrint.Read();
                    if (listNames.Contains(fullname))
                    {
                        do
                        {

                            Thryp++;

                            pasorrd = "";
                            ConsolePrint.Maseg("enter your pasorrd:");
                            pasorrd = ConsolePrint.Read();
                            Namesplit = fullname.Split(' ');
                            if (pasorrd == Data.getCodeName("SELECT secret_code FROM people ", Namesplit[0], Namesplit[1]))
                            {
                                ConsolePrint.Maseg("Correct pasword");
                                return true;
                            }
                            else
                                ConsolePrint.InputErorrs("Not a good pasword pleas Try again");
                        }
                        while (Thryp <= 5);
                        ConsolePrint.InputErorrs("ther are to mach try to password");
                        return false;
                    }
                    else
                        ConsolePrint.InputErorrs($"Ther are no {fullname} user");
                }
                while (TryName <= 5);
                ConsolePrint.InputErorrs("ther are to mach try to enter name");
                return false;
            }
            else if (sing == 2)
            {
                bool goodname = false;
                List<string> listNames = Data.getFullName();
                List<string> listPasword = Data.getOllPasword();
                do
                {
                    TryName++;
                    pasorrd = "";
                    ConsolePrint.Maseg("enter your full name");
                    fullname = ConsolePrint.Read();
                    if (fullname.Split(' ').Length < 2)
                        ConsolePrint.InputErorrs("You nast to split the first name and the kest name with space");
                    else if (!listNames.Contains(fullname))
                    {
                        do
                        {
                            pasorrd = "";
                            ConsolePrint.Maseg("enter a new pasorrd:");
                            pasorrd = ConsolePrint.Read();
                            Namesplit = fullname.Split(' ');
                            if (!listPasword.Contains(pasorrd))
                            {
                                ConsolePrint.Maseg("A good pasword");
                                People newPeople = factory.CreatPeople(fullname, pasorrd);
                                Data.AddPeopleToDB(newPeople);
                                return true;
                            }
                            else
                                ConsolePrint.InputErorrs("Not a good pasword pleas Try again");
                        }
                        while (Thryp <= 5);
                        ConsolePrint.InputErorrs("ther are to mach try to password");
                        return false;
                    }
                    else
                    {
                        ConsolePrint.InputErorrs("The name is in use \nTry another name");
                    }
                }
                while (TryName <= 5);
                ConsolePrint.InputErorrs("ther are to mach try to enter name");
                return false;
            }
            return false;
        }
    }
}

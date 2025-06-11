using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class MainSystem
    {
        public static void start()
        {
            bool Lanch = false;
            bool Run = true;
            int Choce;
            while (Run)
            {
                ConsolePrint.Menulanch();
                Choce = SwitchCoice.GetCoice(1,2);
                if (Choce == -1)
                    break;
                Lanch = lanch.StartLanch(Choce);
                while (!Lanch)
                { 
                    ConsolePrint.Maseg(1);
                    ConsolePrint.Read();
                }
            }
        }
    }
}

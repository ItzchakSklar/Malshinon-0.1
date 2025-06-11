using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Malshinon
{
    internal class Factory
    {
        private static Factory Instance = new Factory();
        private Date date = Date.GetInstans();
        private Random rand = new Random();
        string[] firstNames = {"ertyu", "bobo","pichy","devid","iuybr","liky","maty","tamy"};
        string[] lastNames = {"asdfgh", "slek", "polak", "amelech", "mmkjl" };
        private Factory() { }
        public static Factory getInstance() { return Instance; }
        public void creatRandomPeopleAddUpdateDB(int sum = 3)
        {
            People[] peoples = new People[sum];
            for (int i = 0; i < sum; i++)
            {
                peoples[i] = CreatPeople();
            }
            foreach (People people in peoples)
                date.AddPeopleToDB(people); 
        }
        public People CreatPeople(string fullName = "",string secretCode="",string typePeople= "reporter")
        {
            List<string> existName = date.getFullName();
            int lenFirst = firstNames.Length;
            int lenLast = lastNames.Length;
            int firstRand = 0;
            int lastRand = 0;
            if (fullName == "")
            {
                if (lenFirst * lenLast > existName.Count)
                {
                    bool secsefuly = false;
                    while (!secsefuly)
                    {
                        firstRand = rand.Next(0,lenFirst-1);
                        lastRand = rand.Next(0,lenLast-1);
                        fullName = firstNames[firstRand] +" "+ lastNames[lastRand];
                        if (!existName.Contains(fullName))
                            secsefuly=true;
                    }
                }
                else
                {
                    ConsolePrint.Errors(3);
                    return null;
                }

            }
            if (secretCode == "")
            {
                int size = 6;
                for (int i = 0; i < size; i++)
                {
                    secretCode += (char)rand.Next(96, 122);
                }
            }
            People MinePeople = new People(-1,fullName, secretCode,typePeople,0,0);
            return MinePeople;
        }
        public People CreatPeople(string fullName, string secretCode) { return CreatPeople(fullName, secretCode ,"reporter"); }

        //public IntelReport CreatReports(){}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class People
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string secretCode { get; private set; }
        public string TypePeople { get; private set; }
        public int NumReports { get; private set; }
        public int NumMentions { get; private set; }

        public People(int id, string fullName, string secretCode, string typePeople, int numReports = 0, int numMentions = 0)
        {
            SetId(id);
            SetFullName(fullName);
            SetsecretCode(secretCode);
            SetTypePeople(typePeople);
            SetReportsAndMentions(numReports, numMentions);
        }
        public void SetId(int id) {Id = id;}
        public void SetFullName(string fullName) { FullName = fullName; }
        public void SetsecretCode(string secretCode) { this.secretCode = secretCode; }
        public void SetTypePeople(string typePeople) { TypePeople = typePeople; }
        public void SetReportsAndMentions(int Reports,int Mentions) { NumReports = Reports; NumMentions = Mentions; }
        public void AddReports() { NumReports++; }
        public void AddMentions() { NumMentions++; }
        public override string ToString() 
        {
            return $"{FullName} {secretCode} {TypePeople} Reports: {NumReports} Mentions {NumMentions}";
        }
    }
}

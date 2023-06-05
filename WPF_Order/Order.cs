using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class Order
    {
        public enum NQuality
        {
            Economy,
            Standart,
            Deluxe
        }
        private DateTime[] stayDays;
        public string Name { get; private set; }
        public string ContactInfo { get; private set; }
        public DateTime StartDate => stayDays.FirstOrDefault();
        public DateTime LastDate => stayDays.LastOrDefault();
        public int PeopleCount { get; private set; }
        public NQuality NumberQuality { get; private set; }
        public Order(string name, string contactInfo, int peopleCount, NQuality quality, DateTime[] days)
        {
            Name = name;
            ContactInfo = contactInfo;
            PeopleCount = peopleCount;
            NumberQuality  = quality;
            stayDays = days;
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name : {Name}");
            sb.AppendLine($"Info : {ContactInfo}");
            sb.AppendLine($"Count : {PeopleCount}");
            sb.AppendLine($"Quality : {NumberQuality}");
            sb.AppendLine($"From : {StartDate.ToShortDateString()}");
            sb.AppendLine($"To : {LastDate.ToShortDateString()}");

            return sb.ToString();
        }
    }
}

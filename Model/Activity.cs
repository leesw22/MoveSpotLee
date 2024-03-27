using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Activity:Base
    {
        private string nameActivity;
        private int priceNoPremium;
        private int pricePremium;
        private bool timeLimit;

        public string NameActivity { get => nameActivity; set => nameActivity = value; }
        public int PriceNoPremium { get => priceNoPremium; set => priceNoPremium = value; }
        public int PricePremium { get => pricePremium; set => pricePremium = value; }
        public bool TimeLimit { get => timeLimit; set => timeLimit = value; }

        public override string ToString()
        {
            return this.Id + " " + this.nameActivity + " " + this.priceNoPremium + " " + this.pricePremium +" "+this.timeLimit ;
        }
    }
}

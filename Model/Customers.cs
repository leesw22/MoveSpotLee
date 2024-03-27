using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customers:Person
    {
        private bool isPremium;

        public bool IsPremium { get => isPremium; set => isPremium = value; }

        public override string ToString()
        {
            return this.Id + " " + this.FirstName + " " + this.LastName + " " + this.Phone + " " + this.GenderName.GenderName + " " + this.isPremium;
        }
    }
}

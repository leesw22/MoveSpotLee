using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Coach:Person
    {
        private bool haveDegree;

        public bool HaveDegree { get => haveDegree; set => haveDegree = value; }

        public override string ToString()
        {
            return this.Id +" "+ this.FirstName + " " + this.LastName + " "+ this.Phone+" "+ this.GenderName.GenderName + " " +this.HaveDegree;
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Gender:Base
    {
        string genderName;

        public string GenderName { get => genderName; set => genderName = value; }

        public override string ToString()
        {
            return this.Id + " " + this.genderName;
        }
    }
}

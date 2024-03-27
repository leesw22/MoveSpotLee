using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person:Base
    {
        private string firstName;
        private string lastName;
        private string phone;
        private Gender genderName;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public Gender GenderName { get => genderName; set => genderName = value; }

        public override string ToString()
        {
            return this.Id + " " + this.FirstName + " " + this.LastName + " " + this.Phone + " " + this.GenderName.GenderName ;
        }
    }
}

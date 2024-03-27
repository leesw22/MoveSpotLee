using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonForCustomers:Base
    {
        private Lesson lesson;
        private Customers customers;
        private bool paid;

        public Lesson Lesson { get => lesson; set => lesson = value; }
        public Customers Customers { get => customers; set => customers = value; }
        public bool Paid { get => paid; set => paid = value; }

        public override string ToString()
        {
            return this.Id + " " + this.Lesson.Id + " " + this.Customers.Id + " " + this.paid ;
        }
    }
}

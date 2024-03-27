using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonForCustomersList : List<LessonForCustomers>
    {
        public LessonForCustomersList() { }

        public LessonForCustomersList(IEnumerable<LessonForCustomers> list) : base(list) { }

        public LessonForCustomersList(IEnumerable<Base> list) : base(list.Cast<LessonForCustomers>().ToList()) { }
    }
}

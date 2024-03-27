using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomersList: List<Customers>
    {
        public CustomersList() { }

        public CustomersList(IEnumerable<Customers> list) : base(list) { }

        public CustomersList(IEnumerable<Base> list) : base(list.Cast<Customers>().ToList()) { }
    }
}

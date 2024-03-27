using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CoachList:List<Coach>
    {
        public CoachList() { }

        public CoachList(IEnumerable<Coach> list) : base(list) { }

        public CoachList(IEnumerable<Base> list) : base(list.Cast<Coach>().ToList()) { }
    }
}

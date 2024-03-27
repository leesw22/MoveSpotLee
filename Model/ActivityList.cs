using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ActivityList: List<Activity>
    {
        public ActivityList() { }

        public ActivityList(IEnumerable<Activity> list) : base(list) { }

        public ActivityList(IEnumerable<Base> list) : base(list.Cast<Activity>().ToList()) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonList: List<Lesson>
    {
        public LessonList() { }

        public LessonList(IEnumerable<Lesson> list) : base(list) { }

        public LessonList(IEnumerable<Base> list) : base(list.Cast<Lesson>().ToList()) { }
    }
}

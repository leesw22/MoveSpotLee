using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Lesson:Base
    {
        private Activity activity;
        private Coach coach;
        private DateOnly dateOfLesson;
        private TimeOnly timeStart;
        private TimeOnly timeEnd;
        private int numOfPeople;

        public Activity Activity { get => activity; set => activity = value; }
        public Coach Coach { get => coach; set => coach = value; }
        public DateOnly DateOfLesson { get => dateOfLesson; set => dateOfLesson = value; }
        public TimeOnly TimeStart { get => timeStart; set => timeStart = value; }
        public TimeOnly TimeEnd { get => timeEnd; set => timeEnd = value; }
        public int NumOfPeople { get => numOfPeople; set => numOfPeople = value; }

        public override string ToString()
        {
            return this.Id + " " + this.Activity.Id + " " + this.Coach.Id + " " + this.dateOfLesson + " " + this.timeStart + " " + this.timeEnd +" "+this.numOfPeople;
        }
    }
}

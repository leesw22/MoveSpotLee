using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMoveSpot.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        [HttpPut]
        [ActionName("UpdateActivity")]
        public int UpdateActivity([FromBody] Activity activity)
        {
            ActivityDB aDB = new ActivityDB();
            aDB.Update(activity);
            int x = aDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdatePerson")]
        public int UpdatePerson([FromBody] Person person)
        {
            PersonDB pDB = new PersonDB();
            pDB.Update(person);
            int x = pDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateCoach")]
        public int UpdateCoach([FromBody] Coach coach)
        {
            CoachDB cDB = new CoachDB();
            cDB.Update(coach);
            int x = cDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateCustomers")]
        public int UpdateCustomers([FromBody] Customers customers)
        {
            CustomersDB cDB = new CustomersDB();
            cDB.Update(customers);
            int x = cDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateGender")]
        public int UpdateGender([FromBody] Gender gender)
        {
            GenderDB gDB = new GenderDB();
            gDB.Update(gender);
            int x = gDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateLesson")]
        public int UpdateLesson([FromBody] Lesson lesson)
        {
            LessonDB lDB = new LessonDB();
            lDB.Update(lesson);
            int x = lDB.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateLessonForCustomers")]
        public int UpdateLessonForCustomers([FromBody] LessonForCustomers lessonForCustomers)
        {
            LessonForCustomersDB lDB = new LessonForCustomersDB();
            lDB.Update(lessonForCustomers);
            int x = lDB.SaveChanges();
            return x;
        }
    }
}

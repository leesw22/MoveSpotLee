using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMoveSpot.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpDelete("{id}")]
        [ActionName("DeleteActivity")]
        public int DeleteActivity (int id)
        {
            ActivityDB aDB = new ActivityDB();
            Activity activity = ActivityDB.SelectById(id);
            aDB.Delete(activity);
            int x = aDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeletePerson")]
        public int DeletePerson(int id)
        {
            PersonDB pDB = new PersonDB();
            Person person = PersonDB.SelectById(id);
            pDB.Delete(person);
            int x = pDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteCoach")]
        public int DeleteCoach(int id)
        {
            CoachDB cDB = new CoachDB();
            Coach coach = CoachDB.SelectById(id);
            cDB.Delete(coach);
            int x = cDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteCustomers")]
        public int DeleteCustomers(int id)
        {
            CustomersDB cDB = new CustomersDB();
            Customers customers = CustomersDB.SelectById(id);
            cDB.Delete(customers);
            int x = cDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteGender")]
        public int DeleteGender(int id)
        {
            GenderDB gDB = new GenderDB();
            Gender gender = GenderDB.SelectById(id);
            gDB.Delete(gender);
            int x = gDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteLesson")]
        public int DeleteLesson(int id)
        {
            LessonDB lDB = new LessonDB();
            Lesson lesson = LessonDB.SelectById(id);
            lDB.Delete(lesson);
            int x = lDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteLessonForCustomers")]
        public int DeleteLessonForCustomers(int id)
        {
            LessonForCustomersDB lDB = new LessonForCustomersDB();
            LessonForCustomers lessonForCustomers = LessonForCustomersDB.SelectById(id);
            lDB.Delete(lessonForCustomers);
            int x = lDB.SaveChanges();
            return x;
        }
    }
}

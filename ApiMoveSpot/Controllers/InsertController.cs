using Microsoft.AspNetCore.Mvc;
using Model;
using System.Text.Json;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMoveSpot.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InsertController : ControllerBase
    {
        [HttpPost]
        [ActionName("InsertActivity")]
        public int InsertActivity([FromBody] Activity activity)
        {
            ActivityDB aDB = new ActivityDB();
            aDB.Insert(activity);
            int x = aDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertPerson")]
        public int InsertPerson([FromBody] Person person)
        {
            PersonDB pDB = new PersonDB();
            pDB.Insert(person);
            int x = pDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertCoach")]
        public int InsertCoach([FromBody] Coach coach)
        {
            CoachDB cDB = new CoachDB();
            cDB.Insert(coach);
            int x = cDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertCustomers")]
        public int InsertCustomers([FromBody] Customers customers)
        {
            CustomersDB cDB = new CustomersDB();
            cDB.Insert(customers);
            int x = cDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertGender")]
        public int InsertGender([FromBody] Gender gender)
        {
            GenderDB gDB = new GenderDB();
            gDB.Insert(gender);
            int x = gDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertLesson")]
        public int InsertLesson([FromBody] Lesson lesson)
        {
            LessonDB lDB = new LessonDB();
            lDB.Insert(lesson);
            int x = lDB.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("InsertLessonForCustomers")]
        public int InsertLessonForCustomers([FromBody] LessonForCustomers lessonForCustomers)
        {
            LessonForCustomersDB lDB = new LessonForCustomersDB();
            lDB.Insert(lessonForCustomers);
            int x = lDB.SaveChanges();
            return x;
        }


        [HttpPost]
        [ActionName("LogIn")]
        public ActionResult LogIn([FromBody] JsonElement j)
        {
            PersonDB pDB = new PersonDB();
            string firstName= j.GetProperty("firstName").GetString();
            string lastName = j.GetProperty("lastName").GetString();
            string phone = j.GetProperty("phone").GetString();

            Person p1= pDB.SelectAll().Find(x => x.FirstName== firstName && x.LastName == lastName && x.Phone==phone ) ;
            if (p1 == null)
                return BadRequest(); //שגיאה
            return Ok(p1);
        }

        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register([FromBody] JsonElement j)
        {
            PersonDB pDB = new PersonDB();
            string firstName = j.GetProperty("firstName").GetString();
            string lastName = j.GetProperty("lastName").GetString();
            string phone = j.GetProperty("phone").GetString();
            int gender = j.GetProperty("gender").GetInt32();

            Person p1 = pDB.SelectAll().Find(x => x.FirstName == firstName && x.LastName == lastName && x.Phone == phone && x.GenderName.Id ==gender);
            if (p1 != null)
                return BadRequest(); //שגיאה
            Person p2 = new Person { FirstName = firstName, LastName = lastName, Phone = phone, GenderName = GenderDB.SelectById(gender) };
            pDB.Insert(p2);
            pDB.SaveChanges();
            return Ok(p2);
        }
    }
}

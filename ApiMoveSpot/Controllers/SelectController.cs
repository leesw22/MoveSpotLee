using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMoveSpot.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        [HttpGet]
        [ActionName("SelectAllPerson")]
        public PersonList SelectAllPerson()
        {
            PersonDB pDB = new PersonDB();
            PersonList pList = pDB.SelectAll();
            return pList;
        }

        [HttpGet]
        [ActionName("SelectAllCoach")]
        public CoachList SelectAllCoach()
        {
            CoachDB cDB = new CoachDB();
            CoachList cList = cDB.SelectAll();
            return cList;
        }

        [HttpGet]
        [ActionName("SelectAllCustomers")]
        public CustomersList SelectAllCustomers()
        {
            CustomersDB cDB = new CustomersDB();
            CustomersList cList = cDB.SelectAll();
            return cList;
        }

        [HttpGet]
        [ActionName("SelectAllActivity")]
        public ActivityList SelectAllActivity()
        {
            ActivityDB aDB = new ActivityDB();
            ActivityList aList = aDB.SelectAll();
            return aList;
        }

        [HttpGet]
        [ActionName("SelectAllGender")]
        public GenderList SelectAllGender()
        {
            GenderDB gDB = new GenderDB();
            GenderList gList = gDB.SelectAll();
            return gList;
        }

        [HttpGet]
        [ActionName("SelectAllLesson")]
        public LessonList SelectAllLesson()
        {
            LessonDB lDB = new LessonDB();
            LessonList lList = lDB.SelectAll();
            return lList;
        }

        [HttpGet]
        [ActionName("SelectAllLessonForCustomers")]
        public LessonForCustomersList SelectAllLessonForCustomers()
        {
            LessonForCustomersDB lDB = new LessonForCustomersDB();
            LessonForCustomersList lList = lDB.SelectAll();
            return lList;
        }

    }
}

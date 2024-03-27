using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace ServiceApiMoveSpot
{
    //רשימה של פעולות
    public interface IApiService
    {
        #region person
        Task<PersonList> GetPersonList();
        Task<int> InsertPerson(Person person);
        Task<int> UpdatePerson(Person person);  
        Task<int> DeletePerson(Person person);
        #endregion

        #region coach
        Task<CoachList> GetCoachList();
        Task<int> InsertCoach(Coach coach);
        Task<int> UpdateCoach(Coach coach);
        Task<int> DeleteCoach(Coach coach);
        #endregion

        #region customers
        Task<CustomersList> GetCustomersList();
        Task<int> InsertCustomers(Customers customers);
        Task<int> UpdateCustomers(Customers customers);
        Task<int> DeleteCustomers(Customers customers);
        #endregion

        #region gender
        Task<GenderList> GetGenderList();
        Task<int> InsertGender(Gender gender);
        Task<int> UpdateGender(Gender gender);
        Task<int> DeleteGender(Gender gender);
        #endregion

        #region activity
        Task<ActivityList> GetActivityList();
        Task<int> InsertActivity(Activity activity);
        Task<int> UpdateActivity(Activity activity);
        Task<int> DeleteActivity(Activity activity);
        #endregion

        #region lesson
        Task<LessonList> GetLessonList();
        Task<int> InsertLesson(Lesson lesson);
        Task<int> UpdateLesson(Lesson lesson);
        Task<int> DeleteLesson(Lesson lesson);
        #endregion

        #region lessonForCustomers
        Task<LessonForCustomersList> GetLessonForCustomersList();
        Task<int> InsertLessonForCustomers(LessonForCustomers lessonForCustomers);
        Task<int> UpdateLessonForCustomers(LessonForCustomers lessonForCustomers);
        Task<int> DeleteLessonForCustomers(LessonForCustomers lessonForCustomers);
        #endregion
    }
}

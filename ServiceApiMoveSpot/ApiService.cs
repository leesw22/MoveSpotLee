using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Model;
using static System.Net.WebRequestMethods;


namespace ServiceApiMoveSpot
{
    public class ApiService :IApiService
    {

        #region person
        public async Task<PersonList> GetPersonList()
        {
            HttpClient client = new HttpClient();

            PersonList personList = null;
            try
            {
                string URI = "http://localhost:5103/api/Select/SelectAllPerson";
                personList = await client.GetFromJsonAsync<PersonList>(URI);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return personList;
        }

        public async Task<int> InsertPerson (Person person)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Insert/InsertPerson";
            var x = await client.PostAsJsonAsync<Person>(URI, person);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdatePerson(Person person)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Update/UpdatePerson";
            HttpResponseMessage response = await client.PutAsJsonAsync<Person>(URI, person);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeletePerson (Person person)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync("http://localhost:5103/api/Delete/DeletePerson/" + person.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }

       
        #endregion

        #region coach
        public async Task<CoachList> GetCoachList()
        {
            HttpClient client = new HttpClient();

            CoachList coachList = null;
            try
            {
                string URI = "http://localhost:5103/api/Select/SelectAllCoach";
                coachList = await client.GetFromJsonAsync<CoachList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return coachList;
        }

        public async Task<int> InsertCoach (Coach coach)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Insert/InsertCoach";
            var x = await client.PostAsJsonAsync<Coach>(URI, coach);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateCoach(Coach coach)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Update/UpdateCoach";
            HttpResponseMessage response = await client.PutAsJsonAsync<Person>(URI, coach);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteCoach(Coach coach)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync("http://localhost:5103/api/Delete/DeleteCoach/" + coach.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region customers
        public async Task<CustomersList> GetCustomersList()
        {
            HttpClient client = new HttpClient();

            CustomersList customersList = null;
            try
            {
                string URI = "http://localhost:5103/api/Select/SelectAllCustomers";
                customersList = await client.GetFromJsonAsync<CustomersList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return customersList;
        }

        public async Task<int> InsertCustomers(Customers customers)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Insert/InsertCustomers";
            var x = await client.PostAsJsonAsync<Customers>(URI, customers);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateCustomers(Customers customers)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Update/UpdateCustomers";
            HttpResponseMessage response = await client.PutAsJsonAsync<Customers>(URI, customers);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteCustomers(Customers customers)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync("http://localhost:5103/api/Delete/DeleteCustomers/" + customers.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region gender
        public async Task<GenderList> GetGenderList()
        {
            HttpClient client = new HttpClient();

            GenderList genderList = null;
            try
            {
                string URI = "http://localhost:5103/api/Select/SelectAllGender";
                genderList = await client.GetFromJsonAsync<GenderList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return genderList;
        }

        public async Task<int> InsertGender(Gender gender)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Insert/InsertGender";
            var x = await client.PostAsJsonAsync<Gender>(URI, gender);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateGender(Gender gender)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Update/UpdateGender";
            HttpResponseMessage response = await client.PutAsJsonAsync<Gender>(URI, gender);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteGender(Gender gender)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync("http://localhost:5103/api/Delete/DeleteGender" + gender.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region activity
        public async Task<ActivityList> GetActivityList()
        {
            HttpClient client = new HttpClient();

            ActivityList activityList = null;
            try
            {
                string URI = "http://localhost:5103/api/Select/SelectAllActivity";
                activityList = await client.GetFromJsonAsync<ActivityList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return activityList;
        }

        public async Task<int> InsertActivity(Model.Activity activity)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Insert/InsertActivity";
            var x = await client.PostAsJsonAsync<Model.Activity>(URI, activity);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateActivity(Model.Activity activity)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Update/UpdateActivity";
        
            HttpResponseMessage response = await client.PutAsJsonAsync<Model.Activity>(URI, activity);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteActivity(Model.Activity activity)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync("http://localhost:5103/api/Delete/DeleteActivity/" + activity.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region lesson
        public async Task<LessonList> GetLessonList()
        {
            HttpClient client = new HttpClient();

            LessonList lessonList = null;
            try
            {
                string URI = "http://localhost:5103/api/Select/SelectAllLesson";
                lessonList = await client.GetFromJsonAsync<LessonList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lessonList;
        }

        public async Task<int> InsertLesson(Lesson lesson)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Insert/InsertLesson";
            var x = await client.PostAsJsonAsync<Lesson>(URI, lesson);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateLesson(Lesson lesson)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Update/UpdateLesson";
            HttpResponseMessage response = await client.PutAsJsonAsync<Lesson>(URI, lesson);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteLesson(Lesson lesson)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync("http://localhost:5103/api/Delete/DeleteLesson/" + lesson.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        #region lessonForCustomers
        public async Task<LessonForCustomersList> GetLessonForCustomersList()
        {
            HttpClient client = new HttpClient();

            LessonForCustomersList lessonForCustomersList = null;
            try
            {
                string URI = "http://localhost:5103/api/Select/SelectAllLessonForCustomers";
                lessonForCustomersList = await client.GetFromJsonAsync<LessonForCustomersList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lessonForCustomersList;
        }

        public async Task<int> InsertLessonForCustomers(LessonForCustomers lessonForCustomers)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Insert/InsertLessonForCustomers";
            var x = await client.PostAsJsonAsync<LessonForCustomers>(URI, lessonForCustomers);
            if (x.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> UpdateLessonForCustomers(LessonForCustomers lessonForCustomers)
        {
            HttpClient client = new HttpClient();

            string URI = "http://localhost:5103/api/Update/UpdateLessonForCustomers";
            HttpResponseMessage response = await client.PutAsJsonAsync<LessonForCustomers>(URI, lessonForCustomers);
            if (response.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public async Task<int> DeleteLessonForCustomers(LessonForCustomers lessonForCustomers)
        {
            HttpClient client = new HttpClient();
            int num = 0;
            try
            {
                return (await client.DeleteAsync("http://localhost:5103/api/Delete/DeleteLessonForCustomers/" + lessonForCustomers.Id)).IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return num;
        }
        #endregion

        public async Task<Person> LogIn(string firstName,string lastName, string phone)
        {
            HttpClient client = new HttpClient();
            try
            {
                var x= await client.PostAsJsonAsync<object>("http://localhost:5103/api/Insert/LogIn", new { firstName, lastName, phone });
                return x.IsSuccessStatusCode ? await x.Content.ReadFromJsonAsync<Person>(): null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Person> Register(string firstName, string lastName, string phone , int gender)
        {
            HttpClient client = new HttpClient();
            try
            {
                var x = await client.PostAsJsonAsync<object>("http://localhost:5103/api/Insert/Register", new { firstName, lastName, phone ,gender });
                return x.IsSuccessStatusCode ? await x.Content.ReadFromJsonAsync<Person>() : null;
            }
            catch
            {
                return null;
            }
        }
    }
}

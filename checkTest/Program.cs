// See https://aka.ms/new-console-template for more information


using ViewModel;
using Model;
using System.Security.Cryptography;
using System.Net.Http.Headers;
using ServiceApiMoveSpot;
public class Program
{
    static void Main(string[] args)
    {
            
    }
}

#region selectAll
//Console.WriteLine("gender==>");
//GenderDB genderDB = new GenderDB();
//GenderList gList = genderDB.SelectAll();
//foreach (var c in gList)
//{
//    Console.WriteLine(c.GenderName);
//}

//Console.WriteLine("person==>");
//PersonDB personDB = new PersonDB();
//PersonList pList = personDB.SelectAll();
//foreach (var c in pList)
//{
//    Console.WriteLine(c.FirstName + " " + c.Phone + " " + c.GenderName.GenderName);
//}


//Console.WriteLine("coach==>");
//CoachDB coachDB = new CoachDB();
//CoachList cList = coachDB.SelectAll();
//foreach (var c in cList)
//{
//    Console.WriteLine(c.ToString());
//}

//Console.WriteLine("customers==>");
//CustomersDB customersDB = new CustomersDB();
//CustomersList cuList = customersDB.SelectAll();
//foreach (var c in cuList)
//{
//    Console.WriteLine(c.IsPremium + " " + c.FirstName);
//}

//Console.WriteLine("activity==>");
//ActivityDB activityDB = new ActivityDB();
//ActivityList aList = activityDB.SelectAll();
//foreach (var c in aList)
//{
//    Console.WriteLine(c.Id + " " + c.NameActivity + " " + c.PriceNoPremium + " " + c.PricePremium +" "+c.TimeLimit);
//}

//Console.WriteLine("lesson==>");
//LessonDB lessonDB = new LessonDB();
//LessonList lList = lessonDB.SelectAll();
//foreach (var c in lList)
//{
//    Console.WriteLine(c.Id + ", " + c.Activity.NameActivity+" "+c.Activity.TimeLimit + " ," + c.Coach.FirstName + ", " + c.DateOfLesson
//        + " ," + c.TimeStart + ", " + c.TimeEnd + " ," + c.NumOfPeople);
//}

//Console.WriteLine("lessonForCustomers==>");
//LessonForCustomersDB lessonForCustomersDB = new LessonForCustomersDB();
//LessonForCustomersList l2List = lessonForCustomersDB.SelectAll();
//foreach (var c in l2List)
//{
//    Console.WriteLine(c.Id + ", " + c.Lesson.Id + " ," + c.Customers.Id + ", " + c.Paid);
//}
////הלסן אידי זה לא המחלקה לסן זה עצם שמפורט בלהסן מודל

#endregion

#region Person actions

////   !לאחר שינוי  -- (Person)אחרי הוספה
//PersonDB dB1 = new PersonDB();
//PersonList list1 = dB1.SelectAll();

//Console.WriteLine("after insert person:");
//Person p1 = new Person();
//p1.FirstName = "dan";
//p1.LastName = "tom";
//p1.Phone = "0541258414";
//GenderList gList2 = new GenderDB().SelectAll();
////gList2[0] = נקבה
//// gList2[1] = זכר
//p1.GenderName = gList2[0];
//dB1.Insert(p1);
//dB1.SaveChanges();
//list1 = dB1.SelectAll();


//foreach (var item in list1)
//{
//    Console.WriteLine(item.FirstName);
//    Console.WriteLine(item.LastName);
//    Console.WriteLine(item.Phone);
//    Console.WriteLine(item.GenderName.GenderName);
//    Console.WriteLine("");
//}




////(person)אחרי עדכון שם פרטי 
//Console.WriteLine("after update person:");
//Person pUp = list1.Last();
////Person pUp = list1[5];
//pUp.FirstName = "gad";
//pUp.GenderName = gList2[1];
//dB1.Update(pUp);
//dB1.SaveChanges();
//list1 = dB1.SelectAll();


//foreach (var item in list1)
//{
//    Console.WriteLine(item.FirstName);
//    Console.WriteLine(item.LastName);
//    Console.WriteLine(item.Phone);
//    Console.WriteLine(item.GenderName.GenderName);
//    Console.WriteLine("");
//}



//Console.WriteLine("after delete last person:");
//Person pDelete = list1.Last();
//dB1.Delete(pDelete);
//dB1.SaveChanges();
//list1 = dB1.SelectAll();

//foreach (var item in list1)
//{
//    Console.WriteLine(item.FirstName);
//    Console.WriteLine(item.LastName);
//    Console.WriteLine(item.Phone);
//    Console.WriteLine(item.GenderName.GenderName);
//    Console.WriteLine("");
//}

#endregion

#region coach actions
//Console.WriteLine("after Insert coach");
//CoachDB DB5 = new CoachDB();
//Coach c1 = new Coach() { FirstName = "leo", LastName = "sww", GenderName = GenderDB.SelectById(2), Phone = "0544195842", HaveDegree = true };
//DB5.Insert(c1);
//DB5.SaveChanges();
//Console.WriteLine(DB5.SelectAll().Last().ToString());

//Console.WriteLine("after update coach");
//c1.FirstName = "aviv";
//c1.HaveDegree = false;
////c1.GenderName = GenderDB.SelectById(1);
//DB5.Update(c1);
//DB5.SaveChanges();
//Console.WriteLine(c1.ToString());
//Console.WriteLine(" ");
//CoachList list5 = DB5.SelectAll();
//foreach (var item in list5)
//{
//    Console.WriteLine(item.ToString());
//}

//Console.WriteLine("after delete last coach:");
//Coach cDelete = list5.Last();
//DB5.Delete(cDelete);
//DB5.SaveChanges();
//list5 = DB5.SelectAll();

//foreach (var item in list5)
//{
//    Console.WriteLine(item.ToString());
//}
#endregion

#region customers actions
//Console.WriteLine("after Insert customer");
//CustomersDB DB8 = new CustomersDB();
//Customers c8 = new Customers() { FirstName = "rom", LastName = "pal", GenderName = GenderDB.SelectById(2), Phone = "0541515125", IsPremium = true };
//DB8.Insert(c8);
//DB8.SaveChanges();
//Console.WriteLine(DB8.SelectAll().Last().ToString());

//Console.WriteLine("after update customer");
//c8.FirstName = "gbi";
//c8.IsPremium = false;
//DB8.Update(c8);
//DB8.SaveChanges();
//Console.WriteLine(c8.ToString());
//CustomersList list8 = DB8.SelectAll();
//foreach (var item in list8)
//{
//    Console.WriteLine(item.ToString());
//}

//Console.WriteLine("after delete last customer:");
//Customers cLast = list8.Last();
//DB8.Delete(cLast);
//DB8.SaveChanges();
//list8 = DB8.SelectAll();

//foreach (var item in list8)
//{
//    Console.WriteLine(item.ToString());
//}
#endregion

#region gender actions

//Console.WriteLine("after Insert gender:");
//GenderDB DB9 = new GenderDB();
//Gender g9 = new Gender() {GenderName= "other" };
////g9.GenderName = "other";
//DB9.Insert(g9);
//DB9.SaveChanges();

//GenderList list9 = DB9.SelectAll();
//foreach (var item in list9)
//{
//    Console.WriteLine(item.Id);
//    Console.WriteLine(item.GenderName);
//    Console.WriteLine("");
//}




//Console.WriteLine("after update gender:");
//Gender upG = list9.Last();
//upG.GenderName = "222";
//DB9.Update(upG);
//DB9.SaveChanges();
//list9 = DB9.SelectAll();
//foreach (var item in list9)
//{
//    Console.WriteLine(item.Id);
//    Console.WriteLine(item.GenderName);
//    Console.WriteLine("");
//}



//Console.WriteLine("after delete last gender:");
//Gender gDelete = list9.Last();
//DB9.Delete(gDelete);
//DB9.SaveChanges();
//list9 = DB9.SelectAll();
//foreach (var item in list9)
//{
//    Console.WriteLine(item.Id);
//    Console.WriteLine(item.GenderName);
//    Console.WriteLine("");
//}

#endregion

#region activity actions
//Console.WriteLine("after Insert activity");
//ActivityDB DB10 = new ActivityDB();
//Activity a1 = new Activity() { NameActivity = "pop", PriceNoPremium = 400, PricePremium = 0 ,TimeLimit=true };
//DB10.Insert(a1);
//DB10.SaveChanges();

//Console.WriteLine(DB10.SelectAll().Last().ToString());

//Console.WriteLine(" ");


//Console.WriteLine("after update activity");
//a1.NameActivity = "goobo";
//a1.PriceNoPremium = 1400;
//a1.TimeLimit = false;
//DB10.Update(a1);
//DB10.SaveChanges();
//Console.WriteLine(a1.ToString());
//Console.WriteLine(" ");
//ActivityList list10 = DB10.SelectAll();
//foreach (var item in list10)
//{
//    Console.WriteLine(item.ToString());
//}

//Console.WriteLine("after delete last activity:");
//Activity aDelete = list10.Last();
//DB10.Delete(aDelete);
//DB10.SaveChanges();
//list10 = DB10.SelectAll();

//foreach (var item in list10)
//{
//    Console.WriteLine(item.ToString());
//}
#endregion

#region lesson actions
//Console.WriteLine("after Insert lesson");
//LessonDB DB11 = new LessonDB();
//Lesson l11 = new Lesson() { Activity = ActivityDB.SelectById(6),Coach= CoachDB.SelectById(6), DateOfLesson= new DateOnly(2024,5,22) ,TimeStart =new TimeOnly(12,30), TimeEnd= new TimeOnly(13,15), NumOfPeople=5};
//DB11.Insert(l11);
//DB11.SaveChanges();
//Console.WriteLine(DB11.SelectAll().Last().ToString());

//Console.WriteLine("after update lesson");
//l11.TimeStart = new TimeOnly(12, 15);
//l11.Coach = CoachDB.SelectById(2);
//l11.DateOfLesson = new DateOnly(2024, 5, 21);
//DB11.Update(l11);
//DB11.SaveChanges();
//Console.WriteLine(l11.ToString());
//Console.WriteLine(" ");
//LessonList list11 = DB11.SelectAll();
//foreach (var item in list11)
//{
//    Console.WriteLine(item.ToString());
//}

//Console.WriteLine("after delete last lesson:");
//Lesson lDelete = list11.Last();
//DB11.Delete(lDelete);
//DB11.SaveChanges();
//list11 = DB11.SelectAll();

//foreach (var item in list11)
//{
//    Console.WriteLine(item.ToString());
//}
#endregion

#region lessonForCustomers actions
//Console.WriteLine("after Insert lessonForCustomers");
//LessonForCustomersDB DB12 = new LessonForCustomersDB();
////לתת אופציה של תשלום רק ללקוח שהוא לא פרימיום
//LessonForCustomers l12 = new LessonForCustomers() { Lesson = LessonDB.SelectById(2), Customers = CustomersDB.SelectById(1),Paid=true };
//DB12.Insert(l12);
//DB12.SaveChanges();
//Console.WriteLine(DB12.SelectAll().Last().ToString());

//Console.WriteLine("after update lessonForCustomers");
//l12.Lesson = LessonDB.SelectById(1);
//l12.Paid = false;
//DB12.Update(l12);
//DB12.SaveChanges();
//Console.WriteLine(l12.ToString());
//Console.WriteLine(" ");
//LessonForCustomersList list12 = DB12.SelectAll();
//foreach (var item in list12)
//{
//    Console.WriteLine(item.ToString());
//}

//Console.WriteLine("after delete last lessonForCustomer:");
//LessonForCustomers l2Delete = list12.Last();
//DB12.Delete(l2Delete);
//DB12.SaveChanges();
//list12 = DB12.SelectAll();

//foreach (var item in list12)
//{
//    Console.WriteLine(item.ToString());
//}
#endregion

//ApiService api = new ApiService();
//await api.GetCoachList();
































//Console.WriteLine("enter num");
//int num =int.Parse(Console.ReadLine());
//Console.WriteLine(num+"gg");
//Console.WriteLine("enter num");
//int num = int.Parse(Console.ReadLine());
//Console.WriteLine(num);


 using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LessonDB : BaseDB
    {
        static private LessonList list = new LessonList();

        public LessonDB() : base()
        {
        }

        protected override Base NewEntity()
        {
            return new Lesson();
        }

        protected override Base CreateModel(Base entity)
        {
            Lesson l = entity as Lesson;
            l.Activity = ActivityDB.SelectById(int.Parse(reader["idActivity"].ToString()));
            l.Coach = CoachDB.SelectById(int.Parse(reader["idCoach"].ToString()));
            l.DateOfLesson = DateOnly.FromDateTime(DateTime.Parse(reader["dateOfLesson"].ToString()));
            l.TimeStart = TimeOnly.FromDateTime(DateTime.Parse(reader["timeStart"].ToString()));
            l.TimeEnd = TimeOnly.FromDateTime(DateTime.Parse(reader["timeEnd"].ToString()));
            l.NumOfPeople = int.Parse(reader["numOfPeople"].ToString());
            base.CreateModel(entity);
            return l;

        }
        public LessonList SelectAll()
        {
            command.CommandText = $"SELECT * FROM lessonTbl";
            LessonList lessonList = new LessonList(base.Select());
            return lessonList;

        }
        public static Lesson SelectById(int id)
        {
            if (list.Count == 0)
            {
                LessonDB db = new LessonDB();
                list = db.SelectAll();
            }
            Lesson l = list.Find(item => item.Id == id);
            return l;
        }
        //insert 
        //{
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {

            Lesson l = entity as Lesson;
            if (l != null)
            {
                string sqlStr = $"INSERT INTO lessonTbl (idActivity, idCoach, dateOfLesson," +
                    $" timeStart, timeEnd, numOfPeople) " +
                    $"VALUES (@cidActivity , @cidCoach ,@cdateOfLesson ,@ctimeStart ," +
                    $" @ctimeEnd , @cnumOfPeople)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cidActivity", l.Activity.Id));
                command.Parameters.Add(new OleDbParameter("@cidCoach", l.Coach.Id));
                command.Parameters.Add(new OleDbParameter("@cdateOfLesson", DateTime.Parse(l.DateOfLesson.ToString()).Date));
                command.Parameters.Add(new OleDbParameter("@ctimeStart", DateTime.Parse(l.TimeStart.ToString()).TimeOfDay));
                command.Parameters.Add(new OleDbParameter("@ctimeEnd", DateTime.Parse(l.TimeEnd.ToString()).TimeOfDay));
                command.Parameters.Add(new OleDbParameter("@cnumOfPeople", l.NumOfPeople));
            }
        }

        public override void Insert(Base entity)
        {
            Lesson l = entity as Lesson;
            if (l != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        //}

        //update
        //{
        public override void Update(Base entity)
        {
            Lesson l = entity as Lesson;
            if (l != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));

            }

        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Lesson l = entity as Lesson;

            string sqlStr = $"UPDATE lessonTbl SET" +
                $" idActivity =@cidActivity , idCoach =@cidCoach , dateOfLesson =@cdateOfLesson, timeStart =@ctimeStart," +
                $" timeEnd =@ctimeEnd, numOfPeople =@cnumOfPeople " +
                $" where id =@cId ";
            
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cidActivity", l.Activity.Id));
            command.Parameters.Add(new OleDbParameter("@cidCoach", l.Coach.Id));
            command.Parameters.Add(new OleDbParameter("@cdateOfLesson", DateTime.Parse(l.DateOfLesson.ToString()).Date));
            command.Parameters.Add(new OleDbParameter("@ctimeStart", DateTime.Parse(l.TimeStart.ToString()).TimeOfDay));
            command.Parameters.Add(new OleDbParameter("@ctimeEnd", DateTime.Parse(l.TimeEnd.ToString()).TimeOfDay));
            command.Parameters.Add(new OleDbParameter("@cnumOfPeople", l.NumOfPeople));
            command.Parameters.Add(new OleDbParameter("@cId", l.Id));
        }
        //}

        //delete
        //{
        public override void Delete(Base entity)
        {
            Lesson l = entity as Lesson;
            if (l != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }

        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Lesson l = entity as Lesson;
            string sqlStr = $"DELETE FROM lessonTbl WHERE ID = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", l.Id));


        }
        //}
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LessonForCustomersDB :BaseDB
    {
        static private LessonForCustomersList list = new LessonForCustomersList();

        public LessonForCustomersDB() : base()
        {
        }

        protected override Base NewEntity()
        {
            return new LessonForCustomers();
        }

        protected override Base CreateModel(Base entity)
        {
            LessonForCustomers l2 = entity as LessonForCustomers;
            l2.Lesson = LessonDB.SelectById(int.Parse(reader["idLesson"].ToString()));
            l2.Customers = CustomersDB.SelectById(int.Parse(reader["idCustomer"].ToString()));
            l2.Paid = bool.Parse(reader["paid"].ToString());
            base.CreateModel(entity);
            return l2;
        }
        public LessonForCustomersList SelectAll()
        {
            command.CommandText = $"SELECT * FROM lessonForCustomersTbl";
            LessonForCustomersList lessonForCustomersList = new LessonForCustomersList(base.Select());
            return lessonForCustomersList;

        }

        public static LessonForCustomers SelectById(int id)
        {
            if (list.Count == 0)
            {
                LessonForCustomersDB db = new LessonForCustomersDB();
                list = db.SelectAll();
            }
            LessonForCustomers l = list.Find(item => item.Id == id);
            return l;
        }

        //insert 
        //{
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            LessonForCustomers l2 = entity as LessonForCustomers;
            if (l2 != null)
            {
                string sqlStr = $"INSERT INTO lessonForCustomersTbl (idLesson, idCustomer, paid) " +
                    $"VALUES (@cidLesson  ,@cidCustomer , @cpaid)";


                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cidLesson", l2.Lesson.Id));
                command.Parameters.Add(new OleDbParameter("@cidCustomer", l2.Customers.Id));
                command.Parameters.Add(new OleDbParameter("@cpaid", l2.Paid));
                
            }
        }
        public override void Insert(Base entity)
        {
            LessonForCustomers l2 = entity as LessonForCustomers;
            if (l2 != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        //}

        //update
        //{
        public override void Update(Base entity)
        {
            LessonForCustomers l2 = entity as LessonForCustomers;
            if (l2 != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));

            }

        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            LessonForCustomers l2 = entity as LessonForCustomers;

            string sqlStr = $"UPDATE  lessonForCustomersTbl " +
                $"SET idLesson =@cidLesson , idCustomer = @cidCustomer , paid =@cpaid " +
                $"where     id =@cId ";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cidLesson", l2.Lesson.Id));
            command.Parameters.Add(new OleDbParameter("@cidCustomer", l2.Customers.Id));
            command.Parameters.Add(new OleDbParameter("@cpaid", l2.Paid));
            command.Parameters.Add(new OleDbParameter("@cId", l2.Id));
        }
        //}

        //delete
        //{
        public override void Delete(Base entity)
        {
            LessonForCustomers l2 = entity as LessonForCustomers;
            if (l2 != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }

        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            LessonForCustomers l2 = entity as LessonForCustomers;
            string sqlStr = $"DELETE FROM lessonForCustomersTbl WHERE ID = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", l2.Id));


        }
        //}
    }
}

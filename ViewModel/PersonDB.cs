using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonDB : BaseDB
    {
        static private PersonList list = new PersonList();

        public PersonDB() : base()
        {
        }

        protected override Base NewEntity()
        {
            return new Person();
        }

        protected override Base CreateModel(Base entity)
        {
            Person p = entity as Person;
            p.FirstName = reader["firstName"].ToString();
            p.LastName = reader["lastName"].ToString();
            p.Phone = reader["phone"].ToString();
            p.GenderName = GenderDB.SelectById(int.Parse(reader["genderName"].ToString()));
            base.CreateModel(entity);
            return p;
        }
        public PersonList SelectAll()
        {
            command.CommandText = $"SELECT * FROM personTbl";
            PersonList personList = new PersonList(base.Select());
            return personList;

        }

        public static Person SelectById(int id)
        {
            if (list.Count == 0)
            {
                PersonDB db = new PersonDB();
                list = db.SelectAll();
            }
            Person c = list.Find(item => item.Id == id);
            return c;
        }


        //insert 
        //{
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            Person p = entity as Person;
            if (p != null)
            {
                string sqlStr = $"INSERT INTO personTbl (firstName, lastName, phone ,genderName) " +
                    $"VALUES (@cfirstName,@clastName,@cphone,@cgenderName)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cfirstName", p.FirstName));
                command.Parameters.Add(new OleDbParameter("@clastName", p.LastName));
                command.Parameters.Add(new OleDbParameter("@cphone", p.Phone));
                command.Parameters.Add(new OleDbParameter("@cgenderName", p.GenderName.Id));
            }
        }
        public override void Insert(Base entity)
        {
            Person p = entity as Person;
            if (p != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        //}

        //update
        //{
        public override void Update(Base entity)
        {
            Person p = entity as Person;
            if (p != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));

            }

        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Person p = entity as Person;

            string sqlStr = $"UPDATE  personTbl " +
                $"SET firstName = @cfirstName, lastName =@clastName, phone =@cphone , genderName =@cgenderName " +
                $"where     id =@cId ";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cfirstName", p.FirstName));
            command.Parameters.Add(new OleDbParameter("@clastName", p.LastName));
            command.Parameters.Add(new OleDbParameter("@cphone", p.Phone));
            command.Parameters.Add(new OleDbParameter("@cgenderName", p.GenderName.Id));
            command.Parameters.Add(new OleDbParameter("@cId", p.Id));
        }
        //}

        //delete
        //{
        public override void Delete(Base entity)
        {
            Person p = entity as Person;
            if (p != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }

        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Person p = entity as Person;
            string sqlStr = $"DELETE FROM personTbl WHERE ID = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", p.Id));


        }
        //}
    }

}

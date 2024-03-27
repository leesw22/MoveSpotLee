using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CustomersDB : PersonDB
    {
        static private CustomersList list = new CustomersList();

        public CustomersDB() : base()
        {
        }

        protected override Base NewEntity()
        {
            return new Customers();
        }

        protected override Base CreateModel(Base entity)
        {
            Customers c = entity as Customers;
            c.IsPremium = bool.Parse(reader["isPremium"].ToString());
            base.CreateModel(entity);
            return c;
        }
        public CustomersList SelectAll()
        {
            command.CommandText = $"SELECT personTbl.id, personTbl.firstName, personTbl.lastName," +
                $" personTbl.phone, personTbl.genderName, customersTbl.isPremium " +
                $"FROM (personTbl INNER JOIN customersTbl ON personTbl.id = customersTbl.id)";
            CustomersList customersList = new CustomersList(base.Select());
            return customersList;

        }
        public static Customers SelectById(int id)
        {
            if (list.Count == 0)
            {
                CustomersDB db = new CustomersDB();
                list = db.SelectAll();
            }
            Customers c = list.Find(item => item.Id == id);
            return c;
        }

        //insert 
        //{
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            Customers c = entity as Customers;
            if (c != null)
            {
                string sqlStr = $"INSERT INTO customersTbl (id, isPremium) " +
                    $"VALUES (@cid,@cisPremium)";
                
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cid", c.Id));
                command.Parameters.Add(new OleDbParameter("@cisPremium", c.IsPremium));
                
            }
        }
        public override void Insert(Base entity)
        {
            Customers c = entity as Customers;
            if (c != null)
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        //}

        //update
        //{
        public override void Update(Base entity)
        {
            Customers c = entity as Customers;
            if (c != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }

        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Customers c = entity as Customers;

            string sqlStr = $"UPDATE  customersTbl " +
                $"SET isPremium = @cisPremium  where id =@cId ";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cisPremium", c.IsPremium));
            command.Parameters.Add(new OleDbParameter("@cId", c.Id));
        }
        //}

        //delete
        //{
        public override void Delete(Base entity)
        {
            Customers c = entity as Customers;
            if (c != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }

        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Customers c = entity as Customers;
            string sqlStr = $"DELETE FROM customersTbl WHERE ID = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", c.Id));


        }
        //}
    }
}

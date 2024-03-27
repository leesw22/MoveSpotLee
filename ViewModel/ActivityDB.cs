using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ActivityDB:BaseDB
    {
        static private ActivityList list = new ActivityList();

        public ActivityDB() : base()
        {
        }

        protected override Base NewEntity()
        {
            return new Activity();
        }

        protected override Base CreateModel(Base entity)
        {
            Activity a = entity as Activity;

            a.NameActivity = reader["nameActivity"].ToString();
            a.PriceNoPremium = int.Parse(reader["priceNoPremium"].ToString());
            a.PricePremium = int.Parse(reader["pricePremium"].ToString());
            a.TimeLimit = bool.Parse(reader["timeLimit"].ToString());
            base.CreateModel(entity);
            return a;
        }
        public ActivityList SelectAll()
        {
            command.CommandText = $"SELECT * FROM activityTbl";
            ActivityList activityList = new ActivityList(base.Select());
            return activityList;

        }


        public static Activity SelectById(int id)
        {
            if (list.Count == 0)
            {
                ActivityDB db = new ActivityDB();
                list = db.SelectAll();
            }
            Activity c = list.Find(item => item.Id == id);
            return c;
        }


        //insert 
        //{
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            
            Activity a = entity as Activity;
            if (a != null)
            {
                string sqlStr = $"INSERT INTO activityTbl (nameActivity, priceNoPremium, pricePremium ,timeLimit)" +
                    $"VALUES (@cnameActivity,@cpriceNoPremium,@cpricePremium ,@ctimeLimit)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cnameActivity", a.NameActivity));
                command.Parameters.Add(new OleDbParameter("@cpriceNoPremium", a.PriceNoPremium));
                command.Parameters.Add(new OleDbParameter("@cpricePremium", a.PricePremium));
                command.Parameters.Add(new OleDbParameter("@ctimeLimit", a.TimeLimit));
            }
        }
        public override void Insert(Base entity)
        {
            Activity a = entity as Activity;
            if (a != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        //}

        //update
        //{
        public override void Update(Base entity)
        {
            Activity a = entity as Activity;
            if (a != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));

            }

        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Activity a = entity as Activity;

            string sqlStr = $"UPDATE activityTbl " +
                $" SET nameActivity =@cnameActivity, priceNoPremium =@cpriceNoPremium, pricePremium =@cpricePremium ,timeLimit=@ctimeLimit " +
                $" where  id =@cId ";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cnameActivity", a.NameActivity));
            command.Parameters.Add(new OleDbParameter("@cpriceNoPremium", a.PriceNoPremium));
            command.Parameters.Add(new OleDbParameter("@cpricePremium", a.PricePremium));
            command.Parameters.Add(new OleDbParameter("@ctimeLimit", a.TimeLimit));
            command.Parameters.Add(new OleDbParameter("@cId", a.Id));
        }
        //}

        //delete
        //{
        public override void Delete(Base entity)
        {
            Activity a = entity as Activity;
            if (a != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }

        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Activity a = entity as Activity;
            string sqlStr = $" DELETE FROM activityTbl WHERE id = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", a.Id));


        }
        //}
    }
}

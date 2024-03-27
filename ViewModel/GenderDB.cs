using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GenderDB:BaseDB
    {
        static private GenderList list = new GenderList();

        public GenderDB() : base()
        {
        }

        protected override Base NewEntity()
        {
            return new Gender();
        }

        protected override Base CreateModel(Base entity)
        {
            Gender g = entity as Gender;
            g.GenderName = reader["genderName"].ToString();
            base.CreateModel(entity);
            return g;
        }
        public GenderList SelectAll()
        {
            command.CommandText = $"SELECT id, genderName FROM genderTbl";
            GenderList genderList = new GenderList(base.Select());
            return genderList;

        }
        public static Gender SelectById(int id)
        {
            if (list.Count == 0)
            {
                GenderDB db = new GenderDB();
                list = db.SelectAll();
            }
            Gender g = list.Find(item => item.Id == id);
            return g;
        }
        //insert 
        //{
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {

            Gender a = entity as Gender;
            if (a != null)
            {
                string sqlStr = $"INSERT INTO genderTbl (genderName)" +
                    $"VALUES (@cgenderName)";
                
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cgenderName", a.GenderName)); 
            }
        }
        public override void Insert(Base entity)
        {
            Gender a = entity as Gender;
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
            Gender a = entity as Gender;
            if (a != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));

            }

        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Gender a = entity as Gender;

            string sqlStr = $"UPDATE genderTbl " +
                $"SET genderName =@cgenderName" +
                $"where     id =@cId ";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cnameActivity", a.GenderName));
            command.Parameters.Add(new OleDbParameter("@cId", a.Id));
        }
        //}

        //delete
        //{
        public override void Delete(Base entity)
        {
            Gender a = entity as Gender;
            if (a != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }

        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Gender a = entity as Gender;
            string sqlStr = $"DELETE FROM genderTbl WHERE ID = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", a.Id));


        }
        //}
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CoachDB : PersonDB
    {
        static private CoachList list = new CoachList();

        public CoachDB() : base()
        {
        }

        protected override Base NewEntity()
        {
            return new Coach();
        }

        protected override Base CreateModel(Base entity)
        {
            Coach c = entity as Coach;
            c.HaveDegree = bool.Parse(reader["haveDegree"].ToString());
            base.CreateModel(entity);
            return c;
        }
        public CoachList SelectAll()
        {
            command.CommandText = $"SELECT personTbl.id, personTbl.firstName, personTbl.lastName," +
                $" personTbl.phone, personTbl.genderName, coachTbl.haveDegree " +
                $"FROM (coachTbl INNER JOIN personTbl ON coachTbl.id = personTbl.id)";
            CoachList coachList = new CoachList(base.Select());
            return coachList;

        }
        public static Coach SelectById(int id)
        {
            if (list.Count == 0)
            {
                CoachDB db = new CoachDB();
                list = db.SelectAll();
            }
            Coach c = list.Find(item => item.Id == id);
            return c;
        }

        //insert 
        //{
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            Coach a = entity as Coach;
            if (a != null)
            {
                string sqlStr = $"INSERT INTO coachTbl (id, haveDegree) " +
                    $"VALUES (@cid,@chaveDegree)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cid", a.Id));
                command.Parameters.Add(new OleDbParameter("@chaveDegree", a.HaveDegree));
            }

        }

        public override void Insert(Base entity)
        {
            Coach a = entity as Coach;
            if (a != null)
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
            Coach c = entity as Coach;
            if (c != null)
            {
                //add
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }

        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Coach a = entity as Coach;

            string sqlStr = $"UPDATE coachTbl " +
                $" SET haveDegree =@chaveDegree where id = @cId";
       
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", a.Id));
            command.Parameters.Add(new OleDbParameter("@chaveDegree", a.HaveDegree));
        }
        //}

        //delete
        //{
        public override void Delete(Base entity)
        {
            Coach a = entity as Coach;
            if (a != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }

        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Coach a = entity as Coach;
            string sqlStr = $"DELETE FROM coachTbl WHERE ID = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", a.Id));


        }
        //}

    }
}

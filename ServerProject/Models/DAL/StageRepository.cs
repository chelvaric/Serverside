using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ServerProject.Models.DAL
{
    public class StageRepository
    {

        public static ObservableCollection<INameId> Waardes()
        {
            ObservableCollection<INameId> lijst = new ObservableCollection<INameId>();
            string sql = "SELECT * FROM Festival.Stages";
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {


                lijst.Add(new Stage() { Name = reader["name"].ToString(), ID = reader["ID"].ToString() });

            }

            return lijst;
        }

        public static Stage GetbyID(DbTransaction tran,int id)
        {
            ObservableCollection<INameId> lijst = new ObservableCollection<INameId>();
            string sql = "SELECT * FROM Festival.Stages WHERE ID = @ID";
            DbParameter par = Database.AddParameter("@ID", id);
            DbDataReader reader = Database.GetData(tran,sql,par);
            Stage stage = null;
            while (reader.Read())
            {


               stage =new Stage() { Name = reader["name"].ToString(), ID = reader["ID"].ToString() };

            }

            return stage;
        }

        public static void Add(string name)
        {
            string sql = "INSERT INTO Festival.Stages (Name)  VALUES(@name)";
            DbParameter par = Database.AddParameter("@name", name);
            Database.ModifyData(sql, par);


        }
        public void Delete()
        { }
        public static void Edit(INameId temp)
        {
            string sql = "UPDATE stages SET Name= @name WHERE ID = @ID";
            DbParameter Name = Database.AddParameter("@name", temp.Name);
            DbParameter ID = Database.AddParameter("@ID", temp.ID);
            Database.ModifyData(sql, Name, ID);
        }
    }
}
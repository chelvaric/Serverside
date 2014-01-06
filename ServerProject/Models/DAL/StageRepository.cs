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

        public static ObservableCollection<Stage> Waardes()
        {
            ObservableCollection<Stage> lijst = new ObservableCollection<Stage>();
            string sql = "SELECT * FROM Stages";
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {


                lijst.Add(new Stage() { Name = reader["name"].ToString(), ID = reader["ID"].ToString() });

            }
            if (reader != null)
                reader.Close();  
            return lijst;
        }

        public static Stage GetbyID(int id)
        {
            ObservableCollection<Stage> lijst = new ObservableCollection<Stage>();
            string sql = "SELECT * FROM Stages WHERE ID = @ID";
            DbParameter par = Database.AddParameter("@ID", id);
            DbDataReader reader = Database.GetData(sql,par);
            Stage stage = null;
            while (reader.Read())
            {


               stage =new Stage() { Name = reader["name"].ToString(), ID = reader["ID"].ToString() };

            }
            if (reader != null)
                reader.Close();  
            return stage;
        }

        public static void Add(string name)
        {
            string sql = "INSERT INTO Festival.Stages (Name)  VALUES(@name)";
            DbParameter par = Database.AddParameter("@name", name);
            Database.ModifyData(sql, par);


        }
       
    }
}
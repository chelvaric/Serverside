using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ServerProject.Models.DAL
{
    public class GenreRepository
    {
        public static ObservableCollection<Genre> Waardes()
        {
            ObservableCollection<Genre> lijst = new ObservableCollection<Genre>();
            string sql = "SELECT * FROM Festival.Genres";
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {


                lijst.Add(new Genre() { Name = reader["name"].ToString(), ID = reader["ID"].ToString() });

            }
            if (reader != null)
                reader.Close();  

            return lijst;
        }
        public void Add(string name)
        {
            string sql = "INSERT INTO Festival.Genres (name)  VALUES(@name)";
            DbParameter par = Database.AddParameter("@name", name);
            Database.ModifyData(sql, par);


        }
       
    }
}
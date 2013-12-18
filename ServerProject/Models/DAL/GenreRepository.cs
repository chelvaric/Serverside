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
        public static ObservableCollection<INameId> Waardes()
        {
            ObservableCollection<INameId> lijst = new ObservableCollection<INameId>();
            string sql = "SELECT * FROM Festival.Genres";
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {


                lijst.Add(new Genre() { Name = reader["name"].ToString(), ID = reader["ID"].ToString() });

            }


            return lijst;
        }
        public void Add(string name)
        {
            string sql = "INSERT INTO Festival.Genres (name)  VALUES(@name)";
            DbParameter par = Database.AddParameter("@name", name);
            Database.ModifyData(sql, par);


        }
        public void Delete()
        {

        }
        public void Edit(INameId temp)
        {
            string sql = "UPDATE genres SET name= @name WHERE ID = @ID";
            DbParameter Name = Database.AddParameter("@name", temp.Name);
            DbParameter ID = Database.AddParameter("@ID", temp.ID);
            Database.ModifyData(sql, Name, ID);

        }
    }
}
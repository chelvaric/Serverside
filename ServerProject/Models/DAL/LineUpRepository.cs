using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ServerProject.Models.DAL
{
    public class LineUpRepository
    {


        public static ObservableCollection<LineUp> GetLineUps()
        {
            ObservableCollection<LineUp> templijst = new ObservableCollection<LineUp>();
            string sql = "SELECT * FROM Festival.dbo.lineup";
            DbTransaction tran = Database.BeginTransaction();
            DbDataReader data = Database.GetData(tran,sql);
           
            while (data.Read())
            {
                LineUp temp = new LineUp();

                temp.ID = data["ID"].ToString();
                temp.Date = (DateTime)data["Date"];
                temp.From = data["From"].ToString();
                temp.Till = data["Till"].ToString();
                 temp.Stage =int.Parse( data["StageID"].ToString());
                 temp.Band =  int.Parse(data["BandID"].ToString());
                templijst.Add(temp);
            }
            if (data != null)
                data.Close();  
            return templijst;
        
        }

        public static ObservableCollection<LineUp> GetLineUpsByStage(string id,string date)
        {
            string sql;
          
          
            DbTransaction tran = Database.BeginTransaction();
            DbParameter par ;
            DbParameter parDate ;
            DbDataReader data;
            if (id == "sorteer op Stage" && date == "sorteer op Dag")
            {
                sql = "SELECT * FROM Festival.dbo.lineup";
                data = Database.GetData(tran, sql);
            }
            else {
                if (id == "sorteer op Stage")
                {

                    sql = "SELECT * FROM Festival.dbo.lineup WHERE  Date =  @Date";
                    date = date.Substring(0, 10);
                    string[] lijst = date.Split('/');
                    DateTime datedag = new DateTime(int.Parse(lijst[2]), int.Parse(lijst[1]), int.Parse(lijst[0]));


                    parDate = Database.AddParameter("@Date", datedag);
                    data = Database.GetData(tran, sql, parDate);

                }
                else
                {

                    if (date == "sorteer op Dag")
                    {

                        sql = "SELECT * FROM Festival.dbo.lineup WHERE StageID =  @StageID ";
                        par = Database.AddParameter("@StageID", id);

                        data = Database.GetData(tran, sql, par);
                    }
                    else
                    {
                        date = date.Substring(0, 10);
                        string[] lijst = date.Split('/');

                        DateTime datedag = new DateTime(int.Parse(lijst[2]), int.Parse(lijst[1]), int.Parse(lijst[0]));
                        sql = "SELECT * FROM Festival.dbo.lineup WHERE StageID =  @StageID AND Date =  @Date";
                        par = Database.AddParameter("@StageID", id);
                        parDate = Database.AddParameter("@Date", datedag);
                        data = Database.GetData(tran, sql, par, parDate);
                    }
                }
            }

            ObservableCollection<LineUp> templijst = new ObservableCollection<LineUp>();
       
            
          
           

            while (data.Read())
            {
                LineUp temp = new LineUp();

                temp.ID = data["ID"].ToString();
                temp.Date = (DateTime)data["Date"];
                temp.From = data["From"].ToString();
                temp.Till = data["Till"].ToString();
                temp.Stage = int.Parse(data["StageID"].ToString());
                temp.Band = int.Parse(data["BandID"].ToString());
                templijst.Add(temp);
            }
            if (data != null)
                data.Close();  

            return templijst;

        }

    }
}
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
            string sql = "SELECT * FROM LineUp";
            DbTransaction tran = Database.BeginTransaction();
            DbDataReader data = Database.GetData(tran,sql);
            while (data.Read())
            {
                LineUp temp = new LineUp();

                temp.ID = data["ID"].ToString();
                temp.Date = (DateTime)data["Date"];
                temp.From = data["From"].ToString();
                temp.Till = data["Till"].ToString();
                temp.Stage = StageRepository.GetbyID(tran,int.Parse( data["StageIdD"].ToString()));
                temp.Band = BandRepository.BandByID(tran, int.Parse(data["BandID"].ToString()));
                templijst.Add(temp);
            }
            return templijst;
        
        }


    }
}
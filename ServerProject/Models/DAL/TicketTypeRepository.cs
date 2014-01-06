using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ServerProject.Models.DAL
{
    public class TicketTypeRepository
    {
        public static ObservableCollection<TicketType> GetWaardes()
        {
            ObservableCollection<TicketType> lijst = new ObservableCollection<TicketType>();
            string sql = "SELECT * FROM tickettypes ";


            DbDataReader Reader = Database.GetData(sql);

            while (Reader.Read())
            {
                TicketType temp = new TicketType();
                maakTicketType(Reader, temp);
                lijst.Add(temp);
            }
            if (Reader != null)
                Reader.Close();  

            return lijst;
        }
        public static TicketType Search(string id)
        {
            string sql = "SELECT * FROM tickettypes WHERE ID = @ID";
            DbParameter iD = Database.AddParameter("@ID", id);

            DbDataReader Reader = Database.GetData( sql, iD);
            TicketType temp = new TicketType();
            while (Reader.Read())
            {

                maakTicketType(Reader, temp);
            }
            if (Reader != null)
                Reader.Close();  
            return temp;

        }

        private static void maakTicketType(DbDataReader Reader, TicketType temp)
        {
            temp.ID = Reader["ID"].ToString();
            temp.Name = Reader["Name"].ToString();
            temp.Price = double.Parse(Reader["Price"].ToString());
           temp.AvaibleTickets = int.Parse(Reader["Avaible"].ToString());
        }
       

     
        public static void Edit(TicketType temp)
        {
            string sql = "UPDATE tickettypes SET Avaible=@avaibletickets WHERE ID = @id";
            DbParameter ID = Database.AddParameter("@ID", temp.ID);
            DbParameter pirce = Database.AddParameter("@avaibletickets", temp.AvaibleTickets);
            Database.ModifyData(sql, ID, pirce);

        }
    }
}
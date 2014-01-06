using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ServerProject.Models.DAL
{
    public class TicketRepository
    {
        public static ObservableCollection<Ticket> Waardes()
        {
            ObservableCollection<Ticket> lijst = new ObservableCollection<Ticket>();
            string sql = "SELECT * FROM tickets";
            DbTransaction tran = Database.BeginTransaction();
            DbDataReader Reader = Database.GetData(tran, sql);
            while (Reader.Read())
            {
                Ticket temp = new Ticket();
                MakeTicket(tran, Reader, temp);
                lijst.Add(temp);
            }
            if (Reader != null)
                Reader.Close();  
            return lijst;
        }

        private static void MakeTicket(DbTransaction tran, DbDataReader Reader, Ticket temp)
        {
            temp.ID = Reader["ID"].ToString();
            temp.TicketHolder = Reader["TicketHolder"].ToString();
            temp.TicketHolderEmail = Reader["TicketHolderEmail"].ToString();
            temp.Amount = (int)Reader["amount"];
            temp.TicketType = TicketTypeRepository.Search(Reader["TicketTypeID"].ToString());
        }
       

        
        public static ObservableCollection<Ticket> Search(string ticketType)
        {
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            string sql = "SELECT * FROM tickets  WHERE TicketTypeID = @ID";
            DbTransaction tran = Database.BeginTransaction();
            DbParameter par = Database.AddParameter("@ID", ticketType);
            DbDataReader Reader = Database.GetData(tran, sql, par);
            while (Reader.Read())
            {
                Ticket temp = new Ticket();
                MakeTicket(tran, Reader, temp);
                tickets.Add(temp);
            }
            if (Reader != null)
                Reader.Close();  
            return tickets;

        }
        public static ObservableCollection<Ticket> SearchOnName(string Naam)
        {
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            string sql = "SELECT * FROM tickets  WHERE TicketHolder = @ID";
            DbTransaction tran = Database.BeginTransaction();
            DbParameter par = Database.AddParameter("@ID", Naam);
            DbDataReader Reader = Database.GetData(tran, sql, par);
            while (Reader.Read())
            {
                Ticket temp = new Ticket();
                MakeTicket(tran, Reader, temp);
                tickets.Add(temp);
            }
            if (Reader != null)
                Reader.Close();  
            return tickets;

        }
        public static void Add(string naam, string email, int amount, TicketType type)
        {
            string sql = "INSERT INTO tickets(TicketHolder,TicketHolderEmail,amount,TicketTypeID) VALUES (@TicketHolder,@TicketHolderEmail,@amount,@TicketTypeID)";
            DbParameter parNaam = Database.AddParameter("@TicketHolder", naam);
            DbParameter parEmail = Database.AddParameter("@TicketHolderEmail", email);
            DbParameter parAmount = Database.AddParameter("@amount", amount);
            DbParameter parType = Database.AddParameter("@TicketTypeID", type.ID);
            Database.ModifyData(sql, parAmount, parEmail, parNaam, parType);
        }
    }
}
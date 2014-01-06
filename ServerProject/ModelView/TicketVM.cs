using ServerProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ServerProject.ModelView
{
    public class TicketVM
    {
        private ObservableCollection<Ticket> _tickets;
        public ObservableCollection<Ticket> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; }
        
        
        }
        private ObservableCollection<Ticket> _ticketPersoon;
        public ObservableCollection<Ticket> TicketPersoon
        {
            get { return _ticketPersoon; }
            set { _ticketPersoon = value; }


        }
        
        private ObservableCollection<TicketType> _ticketTypes;

        public ObservableCollection<TicketType> TicketTypes
        {
            get { return _ticketTypes; }
            set { _ticketTypes = value; }
        }

        

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerProject.Models
{
    public class TicketType
    {
        private string _iD;

        public string ID
        {
            get { return _iD; }
            set
            {
                _iD = value;
           
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
           
            }
        }

        private Double _price;

        public Double Price
        {
            get { return _price; }
            set
            {
                _price = value;
   
            }
        }

        private int _avaibleTickets;

        public int AvaibleTickets
        {
            get { return _avaibleTickets; }
            set
            {
                _avaibleTickets = value;

               

            }
        }

      
    }
}
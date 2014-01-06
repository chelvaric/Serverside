using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServerProject.Models
{
    public class Ticket
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
      
        private string _ticketHolder;
         [Required(ErrorMessage = "name is required")]
        public string TicketHolder
        {
            get { return _ticketHolder; }
            set
            {
                _ticketHolder = value;
         
            }
        }

        private string _ticketHolderEmail;
        [Required]
       
        public string TicketHolderEmail
        {
            get { return _ticketHolderEmail; }
            set
            {
                _ticketHolderEmail = value;
    
            }
        }

        private TicketType _ticketType;
        [Required]
        public TicketType TicketType
        {
            get { return _ticketType; }
            set
            {
                _ticketType = value;
    
            }
        }

        private int _amount;
        [Required]
        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
       
            }
        }

       
    }
}
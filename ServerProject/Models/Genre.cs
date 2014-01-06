using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;
using DBHelper;

namespace ServerProject.Models
{
    public class Genre 
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





       
    }
}
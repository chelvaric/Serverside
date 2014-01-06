using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerProject.Models
{
    public class LineUp
    {
        private string _iD;

        public string ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private string _from;

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }
        private string _till;

        public string Till
        {
            get { return _till; }
            set { _till = value; }
        }

        private int _stage;

        public int Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private int _band;

        public int Band
        {
            get { return _band; }
            set { _band = value; }
        }
    }
}
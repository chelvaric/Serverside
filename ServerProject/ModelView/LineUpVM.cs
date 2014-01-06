using ServerProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ServerProject.ModelView
{
    public class LineUpVM
    {

        private ObservableCollection<LineUp> _lineUps;

        public ObservableCollection<LineUp> LineUps
        {
            get { return _lineUps; }
            set { _lineUps = value; }
        }
        private ObservableCollection<Band> _bands;

        public ObservableCollection<Band> Bands
        {
            get { return _bands; }
            set { _bands = value; }
        }
        private ObservableCollection<Stage> _stages;

        public ObservableCollection<Stage> Stages
        {
            get { return _stages; }
            set { _stages = value; }
        }
        private List<DateTime> _dates;

        public List<DateTime> Dates
        {
            get { return _dates; }
            set { _dates = value; }
        }
        private ObservableCollection<Ticket> _tickets;
        public ObservableCollection<Ticket> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; }
        }

    }
}
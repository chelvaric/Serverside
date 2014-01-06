using ServerProject.Models;
using ServerProject.Models.DAL;
using ServerProject.ModelView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBHelper;

namespace ServerProject.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            ObservableCollection<LineUp> templijst =  LineUpRepository.GetLineUps();
            LineUpVM viewdata = new LineUpVM();
            viewdata.LineUps = templijst;
            ObservableCollection<Band> tempbands = new ObservableCollection<Band>();
            ObservableCollection<Stage> tempstage = new ObservableCollection<Stage>();
            DbTransaction tran = Database.BeginTransaction();
            foreach(LineUp temp in viewdata.LineUps)
            {
                tempbands.Add(BandRepository.BandByID(tran,temp.Band));
                tempstage.Add(StageRepository.GetbyID(temp.Stage));
            
            }
           viewdata.Dates = haaldatumsuit(templijst);
           viewdata.Tickets = TicketRepository.Waardes();
            viewdata.Stages = StageRepository.Waardes();
            viewdata.Bands = BandRepository.Bands();
            return View(viewdata);
        }

        public List<DateTime> haaldatumsuit(ObservableCollection<LineUp> lijst)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (LineUp date in lijst)
            {
                if (!dates.Contains(date.Date))
                {
                    dates.Add(date.Date);
                }
            
            }

            return dates;
        }
       [HttpPost]
        public ActionResult Index( string Stage,string Date)
        {
            LineUpVM viewdata = new LineUpVM();
            
          
       
               ObservableCollection<LineUp> templijst = LineUpRepository.GetLineUpsByStage(Stage,Date);
                   

        
            
            viewdata.LineUps = templijst;
            ObservableCollection<Band> tempbands = new ObservableCollection<Band>();
            ObservableCollection<Stage> tempstage = new ObservableCollection<Stage>();
            DbTransaction tran = Database.BeginTransaction();
            foreach (LineUp temp in viewdata.LineUps)
            {
                tempbands.Add(BandRepository.BandByID(tran, temp.Band));
                tempstage.Add(StageRepository.GetbyID(temp.Stage));

            }
            viewdata.Stages = StageRepository.Waardes();
            viewdata.Bands = BandRepository.Bands();
            viewdata.Dates = haaldatumsuit(LineUpRepository.GetLineUps());
           
            return View(viewdata);
        }
        public ActionResult Details(int id)
        {
            DbTransaction tran = Database.BeginTransaction();
           Band band =  BandRepository.BandByID(tran,id);
            

            return View(band);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

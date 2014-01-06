using ServerProject.Models;
using ServerProject.Models.DAL;
using ServerProject.ModelView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerProject.Controllers
{
    public class TicketController : Controller
    {
        //
        // GET: /Ticket/
        
        
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
           
            return PartialView();
        }

        //
        // GET: /Ticket/Details/5
         [Authorize]
        public ActionResult Order()
        {
            TicketVM viewdata = new TicketVM();
            viewdata.Tickets = TicketRepository.Waardes();
            viewdata.TicketTypes = TicketTypeRepository.GetWaardes();
            return View(viewdata);
        }
         [HttpPost]
         [Authorize]
         public ActionResult Order(string Name, string Email, string Amount, string ID)
         {
             TicketVM viewData = new TicketVM();
             viewData.Tickets = TicketRepository.Waardes();
             viewData.TicketTypes = TicketTypeRepository.GetWaardes();
             Ticket temp = new Ticket();
             temp.TicketHolder = Name;
             temp.TicketHolderEmail = Email;
             int avaible = viewData.TicketTypes[int.Parse(ID)-1].AvaibleTickets;
             int aantaltickets =  avaible - int.Parse(Amount);
             if ( aantaltickets  > 0)
             {
                 temp.Amount = int.Parse(Amount);
                 temp.TicketType = viewData.TicketTypes[int.Parse(ID)-1];
                 TicketRepository.Add(temp.TicketHolder, temp.TicketHolderEmail, temp.Amount, temp.TicketType);
              viewData.TicketTypes[int.Parse(ID)].AvaibleTickets -= int.Parse(Amount);
             }
             TicketTypeRepository.Edit(viewData.TicketTypes[int.Parse(ID)-1]);
             viewData.TicketPersoon = TicketRepository.SearchOnName(temp.TicketHolder);
             return View(viewData);
              
         }

        //
        // GET: /Ticket/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ticket/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ticket/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Ticket/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ticket/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Ticket/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

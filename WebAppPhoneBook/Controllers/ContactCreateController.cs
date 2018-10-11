using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPhoneBook.Models;

namespace WebAppPhoneBook.Controllers
{
    public class ContactCreateController : Controller
    {
        // GET: ContactCreate
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactCreate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactCreate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactCreate/Create
        [HttpPost]
        public ActionResult Create(ContactCreateModels obj)
        {
            try
            {
                Contact c = new Contact();
                c.ContactNumber = obj.ContactNumber;
                c.Type = obj.Type;
                c.PersonId = Meduim.MediumData;
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                db.Contacts.Add(c);
                db.SaveChanges();
                return RedirectToAction("Create", "ContactView", new {id = Meduim.MediumData });

                // TODO: Add insert logic here

            }
            catch
            {
                return View();
            }
        }

        // GET: ContactCreate/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View();
        }

        // POST: ContactCreate/Edit/5
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

        // GET: ContactCreate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactCreate/Delete/5
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

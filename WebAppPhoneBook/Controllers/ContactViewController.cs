using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPhoneBook.Models;

namespace WebAppPhoneBook.Controllers
{
    
    public class ContactViewController : Controller
    {
        // GET: ContactView
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactView/Create
        public ActionResult Create()
        {
            
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var model = new List<ContactCreateModels>();
            foreach (Contact c in db.Contacts)
            {
                if (c.PersonId == Meduim.MediumData)
                {
                    ContactCreateModels con = new ContactCreateModels();
                    con.ContactNumber = c.ContactNumber;
                    con.Type = c.Type;
                    con.PersonId = c.PersonId;
                    con.ContactId = c.ContactId;
                    model.Add(con);
                }
            }
            return View(model);
        }

        // POST: ContactView/Create
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                ContactCreateModels con = new ContactCreateModels();
                var model = new List<ContactCreateModels>();
                foreach (Contact c in db.Contacts)
                {
                    if (c.PersonId == Meduim.MediumData)
                    {
                       
                        con.ContactNumber = c.ContactNumber;
                        con.Type = c.Type;
                        con.PersonId = c.PersonId;
                        con.ContactId = c.ContactId;
                        model.Add(con);
                    }
                }
                return View(model);
                // TODO: Add insert logic here
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactView/Edit/5
        public ActionResult Edit(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            ContactEditModels c = new ContactEditModels();
            foreach (Contact a in db.Contacts)
            {
                if(a.ContactId == id)
                {
                    c.ContactNumber  = a.ContactNumber;
                    c.Type = a.Type;
              
                    break;
                }
            }
            
            return View(c);
        }

        // POST: ContactView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContactEditModels obj)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                db.Contacts.Find(id).ContactNumber = obj.ContactNumber;
                db.Contacts.Find(id).Type = obj.Type;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Create","ContactView");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactView/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                Contact d = db.Contacts.Find(id);

                if (d != null)
                {
                    db.Contacts.Remove(d);
                    db.SaveChanges();
                }


                return RedirectToAction("Create", "ContactView");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: ContactView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return View();
            
        }
    }
}

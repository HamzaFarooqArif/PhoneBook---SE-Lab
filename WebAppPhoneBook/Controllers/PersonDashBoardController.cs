using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPhoneBook.Models;

namespace WebAppPhoneBook.Controllers
{
    public class PersonDashBoardController : Controller
    {
        // GET: PersonDashBoard
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonDashBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonDashBoard/Create
        [Authorize]
        public ActionResult Create()
        {
            int count = 0;
            string userid = "";
            string email = User.Identity.Name;
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<AspNetUser> l1 = db.AspNetUsers.ToList<AspNetUser>();
            foreach (AspNetUser a in l1)
            {
                if (a.Email == email)
                {
                    userid = a.Id;
                    break;
                }
            }

            var model = new List<PersonDashboardViewModels>();
            foreach (Person obj in db.People)
            {
                count = count + 1;
                if (obj.AddedBy == userid)
                {
                    PersonDashboardViewModels p = new PersonDashboardViewModels();
                    p.FirstName = obj.FirstName;
                    p.MiddleName = obj.MiddleName;
                    p.LastName = obj.LastName;
                    p.DateOfBirth = obj.DateOfBirth;
                    p.HomeAddress = obj.HomeAddress;
                    p.HomeCity = obj.HomeCity;
                    p.FaceBookAccountId = obj.FaceBookAccountId;
                    p.LinkedInId = obj.LinkedInId;
                    p.ImagePath = obj.ImagePath;
                    p.TwitterId = obj.TwitterId;
                    p.EmailId = obj.EmailId;
                    p.AddedBy = User.Identity.Name;
                    p.AddedOn = obj.AddedOn;
                    p.UpdateOn = obj.UpdateOn;


                    model.Add(p);
                }
            }
            return View(model);
        }

        // POST: PersonDashBoard/Create
        [HttpPost]
        public ActionResult Create(PersonDashboardViewModels mod)
        {
            try
            {
                string userid = "";
                string email = User.Identity.Name;
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                List<AspNetUser> l1 = db.AspNetUsers.ToList<AspNetUser>();
                foreach (AspNetUser a in l1)
                {
                    if (a.Email == email)
                    {
                        userid = a.Id;
                        break;
                    }
                }
                
                var model = new List<PersonDashboardViewModels>();
                foreach (Person obj in db.People)
                {
                    if(obj.AddedBy == userid)
                    {
                        PersonDashboardViewModels p = new PersonDashboardViewModels();
                        p.FirstName = obj.FirstName;
                        p.MiddleName = obj.MiddleName;
                        p.LastName = obj.LastName;
                        p.DateOfBirth = obj.DateOfBirth;
                        p.HomeAddress = obj.HomeAddress;
                        p.HomeCity = obj.HomeCity;
                        p.FaceBookAccountId = obj.FaceBookAccountId;
                        p.LinkedInId = obj.LinkedInId;
                        p.ImagePath = obj.ImagePath;
                        p.TwitterId = obj.TwitterId;
                        p.EmailId = obj.EmailId;
                        p.AddedBy = User.Identity.Name;
                        p.AddedOn = obj.AddedOn;
                        p.UpdateOn = obj.UpdateOn;

                       
                        model.Add(p);
                    }
                }
                View(model);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonDashBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Create","PersonEditModels");
        }

        // POST: PersonDashBoard/Edit/5
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

        // GET: PersonDashBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonDashBoard/Delete/5
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

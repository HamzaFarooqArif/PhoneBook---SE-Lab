using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPhoneBook.Models;

namespace WebAppPhoneBook.Controllers
{
    public class PersonCreateController : Controller
    {
        // GET: PersonCreate
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonCreate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonCreate/Create
        public ActionResult Create()
        {
            String user = User.Identity.Name;
            return View();
        }

        // POST: PersonCreate/Create
        [HttpPost]
        public ActionResult Create(PersonCreateViewModels obj)
        {
            try
            {
                string email;
                email = User.Identity.Name;
                string userid = " ";
                PhoneBookDbEntities db1 = new PhoneBookDbEntities();
                List<AspNetUser> l1 = db1.AspNetUsers.ToList<AspNetUser>();
                foreach(AspNetUser a in l1)
                {
                    if(a.Email == email)
                    {
                        userid = a.Id;
                        break;
                    }
                }
              
                

                


                Person p = new Person();
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
                p.AddedBy = userid;
                p.AddedOn = DateTime.Now;
                p.UpdateOn = DateTime.Now;
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                
                db.People.Add(p);
                db.SaveChanges();

                return RedirectToAction("Create","PersonCreate");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonCreate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonCreate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Create", "PersonEdit");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonCreate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonCreate/Delete/5
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

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
            Meduim.MediumData = id;
            return RedirectToAction("Create", "ContactView");          

        }
       
        // GET: PersonDashBoard/Create
        [Authorize]
        public ActionResult Create()
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
                if (obj.AddedBy == userid)
                {
                    PersonDashboardViewModels p = new PersonDashboardViewModels();
                    p.PersonId = obj.PersonId;
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
                        p.PersonId = obj.PersonId;
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
            PersonEditModels m = new PersonEditModels();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            foreach(Person p in db.People)
            {
                if(p.PersonId == id)
                {
                    m.FirstName = p.FirstName;
                    m.MiddleName = p.MiddleName;
                    m.LastName = p.LastName;
                    m.DateOfBirth = p.DateOfBirth;
                    m.HomeAddress = p.HomeAddress;
                    m.HomeCity = p.HomeCity;
                    m.FaceBookAccountId = p.FaceBookAccountId;
                    m.LinkedInId = p.LinkedInId;
                    m.ImagePath = p.ImagePath;
                    m.TwitterId = p.TwitterId;
                    m.EmailId = p.EmailId;
                    break;
                }
            }
            
            return View(m);
        }

        // POST: PersonDashBoard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonEditModels obj)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                db.People.Find(id).FirstName = obj.FirstName;
                db.People.Find(id).MiddleName = obj.MiddleName;
                db.People.Find(id).LastName = obj.LastName;
                db.People.Find(id).DateOfBirth = obj.DateOfBirth;
                db.People.Find(id).HomeAddress = obj.HomeAddress;
                db.People.Find(id).HomeCity = obj.HomeCity;
                db.People.Find(id).FaceBookAccountId = obj.FaceBookAccountId;
                db.People.Find(id).LinkedInId = obj.LinkedInId;
                db.People.Find(id).TwitterId = obj.TwitterId;
                db.People.Find(id).EmailId = obj.EmailId;
                db.People.Find(id).UpdateOn = DateTime.Now;
                db.People.Find(id).ImagePath = obj.ImagePath;

                db.SaveChanges();
                
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
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            foreach(Contact c in db.Contacts)
            {
                if(c.PersonId == id)
                {
                    db.Contacts.Remove(c);
                }
            }
            Person myperson = new Person();
            foreach(Person p in db.People)
            {
                if(p.PersonId == id)
                {
                    myperson = p;
                    break;
                }
            }
            db.People.Remove(myperson);
            db.SaveChanges();
            return RedirectToAction("Create", "PersonDashBoard");
        }

        // POST: PersonDashBoard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

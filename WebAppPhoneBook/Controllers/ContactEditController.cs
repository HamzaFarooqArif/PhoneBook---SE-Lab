using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppPhoneBook.Controllers
{
    public class ContactEditController : Controller
    {
        // GET: ContactEdit
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactEdit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactEdit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactEdit/Create
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

        // GET: ContactEdit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactEdit/Edit/5
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

        // GET: ContactEdit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactEdit/Delete/5
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

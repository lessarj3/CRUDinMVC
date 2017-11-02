using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDinMVC.Models;

namespace CRUDinMVC.Controllers
{
    public class MixController : Controller
    {
        // 1. *************RETRIEVE ALL MIX DETAILS ******************
        // GET: Mix
        public ActionResult Index()
        {
            MixDBHandle dbhandle = new MixDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetMix());
        }

        // 2. *************ADD NEW MIX ******************
        // GET: Mix/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mix/Create
        [HttpPost]
        public ActionResult Create(MixModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MixDBHandle sdb = new MixDBHandle();
                    if (sdb.AddMix(smodel))
                    {
                        ViewBag.Message = "Mix Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View(); ; ; ;
            }
        }

        // 3. ************* EDIT MIX DETAILS ******************
        // GET: Mix/Edit/5
        public ActionResult Edit(int id)
        {
            MixDBHandle sdb = new MixDBHandle();
            return View(sdb.GetMix().Find(smodel => smodel.Id == id));
        }

        // POST: Mix/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MixModel smodel)
        {
            try
            {
                MixDBHandle sdb = new MixDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 4. ************* DELETE MIX DETAILS ******************
        // GET: Mix/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                MixDBHandle sdb = new MixDBHandle();
                if (sdb.DeleteMix(id))
                {
                    ViewBag.AlertMsg = "Mix Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

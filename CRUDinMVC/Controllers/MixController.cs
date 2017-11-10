using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CRUDinMVC.Models;
using CathRepoCommon.Models;
using CRUDinMVC.Common.Data;

namespace CRUDinMVC.Controllers
{
    public class MixController : Controller
    {
        private readonly IMixRepository _mixRepository;

        //**********DATA MANAGEMENT SELECTION*************
        public MixController()
        {
            // This line of code for using SQL
            //_mixRepository = new MixRepositorySQL();

            // This line of code is for using MongoDB
            //_mixRepository = new MixRepositoryMongo();

            // This line of code is for using In Memory
            _mixRepository = new MixRepositoryInMemory();
        }
        //*************RETRIEVE ALL MIXES******************
        // GET
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(_mixRepository.GetMixes());
        }

        // 2. *************ADD NEW MIX ******************
        // GET: Mix/Create
        public ActionResult Create()
        {
            return View();
        }

        // 3. ************* View MIX DETAILS ******************
        // GET: Mix/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_mixRepository.GetMixes().FirstOrDefault(m => m.Id == id));
        }

        // POST: Mix/Create
        [HttpPost]
        public ActionResult Create(Mix mix)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    _mixRepository.AddMix(mix);
                }
                TempData["Created"] = "Mix added successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Created"] = "Error! Somethings amiss!";
                return View(); 
            }
        }

        // 3. ************* EDIT MIX DETAILS ******************
        // GET: Mix/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_mixRepository.GetMixes().FirstOrDefault(m => m.Id == id));
        }

        // POST: Mix/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Mix mix)
        {
            try
            {
                _mixRepository.UpdateDetails(mix);
                TempData["Edited"] = "Mix was changed!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Edited"] = "Update failed...";
                return View();
            }
        }

        // 4. ************* DELETE MIX DETAILS ******************
        // GET: Mix/Delete/5
        public ActionResult Delete(int id)
        {
            int mix = id;
            try
            {
                _mixRepository.DeleteMix(id);
                TempData["Deleted"] = "Mix was deleted!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Deleted"] = "Error! Somethings amiss!";
                return View();
            }
        }
    }
}

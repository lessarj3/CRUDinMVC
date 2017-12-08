using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CRUDinMVC.Models;
using CathRepoCommon.Models;

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
            //_mixRepository = new MixRepositoryInMemory();

            //Gets IMixRepository implementation from factory
            _mixRepository = MixRepositoryFactory.Get();
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
        public ActionResult Details(string id)
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
                    TempData["Created"] = "Mix added successfully!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch(Exception)
            {
                TempData["Error"] = "Error! Mix not created!";
                return View();
            }
        }

        // 3. ************* EDIT MIX DETAILS ******************
        // GET: Mix/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(_mixRepository.GetMixes().FirstOrDefault(m => m.Id == id));
        }

        // POST: Mix/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Mix mix)
        {
            try
            {
                _mixRepository.UpdateDetails(mix);
                TempData["Edited"] = "Mix was changed!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Update failed... :(";
                return View();
            }
        }

        // 4. ************* DELETE MIX DETAILS ******************
        // GET: Mix/Delete/5
        public ActionResult Delete(string id)
        {
            var mix = id;
            try
            {
                _mixRepository.DeleteMix(id);
                TempData["Deleted"] = "Mix was deleted!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Error! Mix not deleted!";
                return View();
            }
        }
        //Display Mix and Pellet Data
        public ActionResult MixWithPellets(string id)
        {
           
           
            return View(_mixRepository.GetMixes().FirstOrDefault(m => m.Id == id));
            
    }}
}

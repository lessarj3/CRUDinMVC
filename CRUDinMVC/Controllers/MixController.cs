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
        //[HttpGet]
        //public ActionResult Details(int id)
        //{
        //    return View(_mixRepository.GetMixes().FirstOrDefault(m => m.Id == id));
        //}

        public ActionResult Details(string Id)
        {
            Mix mix = _mixRepository.GetMixes().FirstOrDefault(m => m.Id == Id);
            return PartialView("_Details", mix);
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
                    TempData["Message"] = "Mix added successfully!";
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch
            {
                TempData["Message"] = "Error! Somethings amiss!";
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
            //try
            //{
            //    _mixRepository.UpdateDetails(mix);
            //    TempData["Message"] = "Mix was changed!";
            //    return RedirectToAction("Index");
            //}
            //catch
            {
                TempData["Message"] = "Error! Update failed...";
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
                TempData["Message"] = "Mix was deleted!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Error! Somethings amiss!";
                return View();
            }
        }
        //Display Mix and Pellet Data
        public ActionResult MixWithPellets(string id)
        {                
            return View(_mixRepository.GetMixes().FirstOrDefault(m => m.Id == id));
            
    }}
}

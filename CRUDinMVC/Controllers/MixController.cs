using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CathRepoCommon.Models;
using CRUDinMVC.ViewModels;


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
        public ActionResult Index(IEnumerable<Mix> mixes)
        {
            ModelState.Clear();
            if (mixes != null)
                return View(mixes);
            else
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
                    TempData["Message"] = "Mix added successfully!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch(Exception)
            {
                TempData["Message"] = "Error! Mix not created!";
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
                TempData["Message"] = "Mix was changed!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Error! Update failed... :(";
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
                TempData["Message"] = "Error! Mix not deleted!";
                return View();
            }
        }
        //Display Mix and Pellet Data
        public ActionResult MixWithPellets(string id)
        {
            var mix = _mixRepository.GetMixes().FirstOrDefault(m => m.Id == id);
            var vm = new MixViewModel();
            vm.MixName = mix.MixName;
            vm.Pellets = mix.Pellets;
            vm.CFx = mix.CFx;
            vm.SVO = mix.SVO;
            vm.Carbon = mix.Carbon;
            vm.Binder = mix.Binder;
            vm.Ratio = mix.Ratio;
            vm.ActiveMaterial = mix.ActiveMaterial;
            vm.mAh = mix.mAh;

            //(p => p.Mass) Lambda expression, means for each pellet, select the mass
            double pelletMassAverage = mix.Pellets != null && mix.Pellets.Count() > 0 ? mix.Pellets.Average(p => p.Mass):0;                     
            double pelletDiameterAverage = mix.Pellets != null && mix.Pellets.Count() > 0 ? mix.Pellets.Average(p => p.Diameter) : 0;
            double pelletThicknessAverage = mix.Pellets != null && mix.Pellets.Count() > 0 ? mix.Pellets.Average(p => p.Thickness) : 0;
            double pelletResistanceAverage = mix.Pellets != null && mix.Pellets.Count() > 0 ? mix.Pellets.Average(p => p.Resistance) : 0;
            double pelletVolumeAverage = Math.Round(Math.PI * (((Math.Pow((pelletDiameterAverage/2), 2)/100) * (pelletThicknessAverage)/10)), 3);
            double pelletDensityAverage = Math.Round((pelletMassAverage / pelletVolumeAverage),3);
            //Setting averages the viewModel (vm)
            vm.PelletDensityAverage = pelletDensityAverage;
            vm.PelletVolumeAverage = pelletVolumeAverage;
            vm.PelletMassAverage = pelletMassAverage;
            vm.PelletThicknessAverage = pelletThicknessAverage;
            vm.PelletDiameterAverage= pelletDiameterAverage;
            vm.PelletResistnaceAverage= pelletResistanceAverage;
            //other calculations


            return View(vm);    
        }



        public ActionResult EditPellets(string Id)
        {
            Mix mix = _mixRepository.GetMixes().FirstOrDefault(m => m.Id == Id);
            var view = PartialView("_EditPellets", mix.Pellets);
            view.ViewBag.MixId = Id;
            return view;
        }

        // GET
        public ActionResult Search()
        {
            ModelState.Clear();
            return View("SearchForm");
        }

        // POST: SearchForm
        [HttpPost]
        public ActionResult Search(MixSearchFilter filter)
        {
            try
            {
                var mixes = _mixRepository.GetMixes(filter);
                return View("Index", mixes);
            }
            catch (Exception)
            {
                ViewData["Message"] = "Search Error!";
                return View("SearchForm");
            }
        }
    }
}

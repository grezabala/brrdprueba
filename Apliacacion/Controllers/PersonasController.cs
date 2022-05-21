using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Infraestructura.Repositorio;
using App.Dominio.Entidades;

namespace Apliacacion.Controllers
{
    public class PersonasController : Controller
    {
        //Llamada al Repositorio 
        private PersonaRepositorio Repo { get; }
        //Llamada al DbContext
        private AplicacionDbContext DbContext { get; } = new AplicacionDbContext();

        public PersonasController()
        {
            Repo = new PersonaRepositorio(DbContext);
        }


        // GET: Personas
        [HttpGet]
        public ActionResult Index()
        {
            return View(Repo.Get().ToList());
        }

        //GET: Personas
        public ActionResult Add() 
        {
            return View(); 
        }

        //POST: Personas
        [HttpPost]
        public ActionResult Add(Personas model) 
        {

            if (ModelState.IsValid)
            {
                if (Repo.Add(model))
                {
                    return RedirectToAction("Index");
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Error! " + " No fue registrado");
                    return View(model);
                }
            }
            else 
            {
                ModelState.AddModelError("Error", "No fue registrado");
                return View();
            }
        
        }

        //GET: Delete/Personas
        [HttpGet]
        public ActionResult Delete(int Id)  
        {
            if (Repo.Delete(Id))
            {
                return RedirectToAction("Index");
            }
            else 
            {
                return RedirectToAction("Index");
            }
        
        }

        //GET: Update/Personas
        [HttpGet]
        public ActionResult Update(int Id) 
        {
            if (Id <= 0) 
            {
                return RedirectToAction("Index");
            }

            var buscarUpdate = Repo.GetById(Id);

            if (buscarUpdate == null)
            {
                return RedirectToAction("Index");
            }
            else 
            {
                return View(buscarUpdate);
            }
        }

        //PUT: Update/Personas
        [HttpPost]
        public ActionResult Update(Personas model, int Id) 
        {
            if (ModelState.IsValid)
            {
                model.ID = Id;
                if (Repo.Update(model))
                {
                    return RedirectToAction("Index");
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Error!" + "Su datos no fueron Modificado");
                    return View(model);
                }
            }
            else 
            {
                ModelState.AddModelError("Error!", "Su datos no fueron Modificado");
                return View();
            }
        }
    }
}
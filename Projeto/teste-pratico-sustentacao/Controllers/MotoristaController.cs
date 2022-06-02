using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using teste_pratico_sustentacao.Interface;
using teste_pratico_sustentacao.Models;

namespace teste_pratico_sustentacao.Controllers
{
    public class MotoristaController : Controller
    {
        private readonly IMotoristaService _motoristaService;
        public MotoristaController(IMotoristaService motoristaService)
        {
            _motoristaService = motoristaService;
        }

        public ActionResult Index()
        {
            return View(_motoristaService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_motoristaService.GetById(id));
        }

        public ActionResult Create()
        {
            return View(new Motorista());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                var retorno = _motoristaService.Salvar(motorista);
                if (retorno != "")
                    throw new Exception(retorno);

                return RedirectToAction("Index");
            }
            else
            {
                return View(motorista);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_motoristaService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                var retorno = _motoristaService.Salvar(motorista);
                if (retorno != "")
                    throw new Exception(retorno);
                return RedirectToAction("Index");
            }
            else
            {
                return View(motorista);
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_motoristaService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Motorista motorista)
        {
            _motoristaService.Delete(motorista);
            return RedirectToAction("Index");
        }
    }
}

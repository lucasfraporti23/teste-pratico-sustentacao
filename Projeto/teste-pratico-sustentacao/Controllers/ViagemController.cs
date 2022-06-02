using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using teste_pratico_sustentacao.Interface;
using teste_pratico_sustentacao.Models;

namespace teste_pratico_sustentacao.Controllers
{
    public class ViagemController : Controller
    {
        private readonly IViagemService _viagemService;
        public ViagemController(IViagemService viagemService)
        {
            _viagemService = viagemService;
        }

        public ActionResult Index()
        {
            return View(_viagemService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_viagemService.GetById(id));
        }

        public ActionResult Create()
        {
            return View(new Viagem());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                var retorno = _viagemService.Salvar(viagem);
                if (retorno != "")
                    throw new Exception(retorno);

                return RedirectToAction("Index");
            }
            else
            {
                return View(viagem);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_viagemService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                var retorno = _viagemService.Salvar(viagem);
                if (retorno != "")
                    throw new Exception(retorno);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viagem);
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_viagemService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Viagem viagem)
        {
            _viagemService.Delete(viagem);
            return RedirectToAction("Index");
        }
    }
}

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
            var retorno = new ViagemAuxiliar();
            retorno.BuscaMotorista = new BuscaMotorista();

            retorno.BuscaMotorista.ListaMotorista.Add(new Motorista());

            var listaDeMotorista = _viagemService.CarregarMotoristas();

            foreach (var item in listaDeMotorista)
            {
                retorno.BuscaMotorista.ListaMotorista.Add(item);
            }
            return View(retorno);
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
            var retorno = _viagemService.GetById(id);
            retorno.BuscaMotorista = new BuscaMotorista();
            retorno.BuscaMotorista.ListaMotorista.Add(new Motorista());
            var listaDeMotoristas = _viagemService.CarregarMotoristas();
            foreach (var item in listaDeMotoristas)
            {
                retorno.BuscaMotorista.ListaMotorista.Add(item);
            }
            return View(retorno);
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
            var retorno = _viagemService.DeleteById(viagem.Id);
            if (retorno != "")
                throw new Exception(retorno);

            return RedirectToAction("Index");
        }
    }
}

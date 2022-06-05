using System;
using System.Collections.Generic;
using teste_pratico_sustentacao.Interface;
using teste_pratico_sustentacao.Models;
using teste_pratico_sustentacao.Repository;

namespace teste_pratico_sustentacao.Service
{
    public class ViagemService : IViagemService
    {
        public string Salvar(Viagem dados)
        {
            var retorno = "";
            try
            {
                var viagemRepository = new ViagemRepository();
                if (dados != null)
                {
                    if (dados.Id == 0)
                    {
                        viagemRepository.Save(dados);
                    }
                    else
                    {
                        viagemRepository.Update(dados);
                    }
                }
                else
                    retorno = "Os dados da viagem não foram informados.";
            }
            catch (Exception erro)
            {
                retorno = erro.Message;
            }
            return retorno;
        }
        public string DeleteById(int id)
        {
            var retorno = "";
            try
            {
                new ViagemRepository().DeleteById(id);
            }
            catch (Exception erro)
            {
                retorno = erro.Message;
            }
            return retorno;
        }
        public List<ViagemAuxiliar> GetAll(string filtro = "")
        {
            return new ViagemRepository().GetAll(filtro);
        }
        public ViagemAuxiliar GetById(int id)
        {
            return new ViagemRepository().GetById(id);
        }
        public List<Motorista> CarregarMotoristas()
        {
            return new MotoristaRepository().CarregarMotoristas();
        }
    }
}

using System;
using System.Collections.Generic;
using teste_pratico_sustentacao.Interface;
using teste_pratico_sustentacao.Models;
using teste_pratico_sustentacao.Repository;

namespace teste_pratico_sustentacao.Service
{
    public class MotoristaService: IMotoristaService
    {
        public string Salvar(Motorista dados)
        {
            var retorno = "";
            try
            {
                var motoristaRepository = new MotoristaRepository();
                if (dados != null)
                {
                    if (dados.Id == 0)
                    {
                        var placaRepetida = motoristaRepository.VerificarPlacaRepetida(dados.Placa);
                        if (placaRepetida)
                            retorno = "A placa informada já existe!";
                    }
                    if (string.IsNullOrEmpty(retorno))
                        motoristaRepository.Save(dados);
                }
                else
                    retorno = "Os dados do motorista não foram informados.";
            }
            catch (Exception erro)
            {
                retorno = erro.Message;
            }
            return retorno;
        }
        public string PermiteDeletar(int id)
        {
            var retorno = string.Empty;

            if (id > 0)
            {
                var motoristaEmViagem = new MotoristaRepository().VerificarMotoristaEmViagem(id);
                if (motoristaEmViagem)
                    retorno = "Não é possivel excluir, o motorista está em viagem!";
            }
            else
                retorno = "Não foi informado o código do motorista.";

            return retorno;
        }
        public string Delete(Motorista dados)
        {
            var retorno = "";
            try
            {
                retorno = PermiteDeletar(dados.Id);

                if (string.IsNullOrEmpty(retorno))
                    new MotoristaRepository().DeleteById(dados.Id);
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
                retorno = PermiteDeletar(id);

                if (string.IsNullOrEmpty(retorno))
                    new MotoristaRepository().DeleteById(id);
            }
            catch (Exception erro)
            {
                retorno = erro.Message;
            }
            return retorno;
        }
        public List<Motorista> GetAll(string filtro = "")
        {
            return new MotoristaRepository().GetAll(filtro);
        }
        public Motorista GetById(int id)
        {
            return new MotoristaRepository().GetById(id);
        }
    }
}


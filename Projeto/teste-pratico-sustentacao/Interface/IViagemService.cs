using System.Collections.Generic;
using teste_pratico_sustentacao.Models;

namespace teste_pratico_sustentacao.Interface
{
    public interface IViagemService
    {
        public string Salvar(Viagem dados);
        public string DeleteById(int id);
        public List<ViagemAuxiliar> GetAll(string filtro = "");
        public ViagemAuxiliar GetById(int id);
        public List<Motorista> CarregarMotoristas();
    }
}

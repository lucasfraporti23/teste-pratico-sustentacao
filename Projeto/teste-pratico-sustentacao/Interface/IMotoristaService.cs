using System.Collections.Generic;
using teste_pratico_sustentacao.Models;

namespace teste_pratico_sustentacao.Interface
{
    public interface IMotoristaService
    {
        public string Salvar(Motorista dados);
        public string PermiteDeletar(int id);
        public string Delete(Motorista dados);
        public string DeleteById(int id);
        public List<Motorista> GetAll(string filtro = "");
        public Motorista GetById(int id);
    }
}

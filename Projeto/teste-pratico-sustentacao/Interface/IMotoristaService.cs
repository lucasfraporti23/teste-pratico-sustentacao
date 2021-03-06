using System.Collections.Generic;
using teste_pratico_sustentacao.Models;

namespace teste_pratico_sustentacao.Interface
{
    public interface IMotoristaService
    {
        public string Salvar(Motorista dados);
        public string PermiteDeletar(int id);
        public string DeleteById(int id);
        public List<Motorista> GetAll();
        public Motorista GetById(int id);
    }
}

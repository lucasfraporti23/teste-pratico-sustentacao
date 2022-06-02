using System;

namespace teste_pratico_sustentacao.Models
{
    public class Viagem
    {
        public int Id { get; set; }
        public DateTime DataViagem { get; set; }
        public string LocalEntrega { get; set; }
        public string LocalSaida { get; set; }
        public decimal Km { get; set; }
        public int MotoristaId { get; set; }
    }
}

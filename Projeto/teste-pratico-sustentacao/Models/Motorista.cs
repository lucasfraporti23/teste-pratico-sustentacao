using System.ComponentModel.DataAnnotations;

namespace teste_pratico_sustentacao.Models
{
    public class Motorista
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Eixos { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Pais { get; set; }
    }
}

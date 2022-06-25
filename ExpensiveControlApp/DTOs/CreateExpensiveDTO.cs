using System.ComponentModel.DataAnnotations;

namespace ExpensiveControlApp.DTOs
{
    public class CreateExpensiveDTO
    {

        [Required(ErrorMessage = "Descrição é Obrigatoria.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Valor é Obrigatorio.")]
        [Range(0.01, 999999999, ErrorMessage = "Valor deve ser maior que 0.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Data é Obrigatorio.")]
        public DateTime Date { get; set; }
    }
}

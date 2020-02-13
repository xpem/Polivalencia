using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe um nome", AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DtNascimento { get; set; }
        public string Cidade { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Informe um telefone válido")]
        public string Telefone { get; set; }

        [Display(Name = "Habilitações")]
        public List<Habilitacao> habilitacoes { get; set; }

    }


    
}

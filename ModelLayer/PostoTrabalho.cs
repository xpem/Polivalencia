using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
   public class PostoTrabalho
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe um nome", AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Informe um Tipo", AllowEmptyStrings = false)]
        [MaxLength(50)]
        public int Tipo { get; set; }

        [Display(Name = "Tipo")]
        [MaxLength(250)]
        public string Descricao { get; set; }
    }
}

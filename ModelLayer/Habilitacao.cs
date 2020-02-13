using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Habilitacao
    {
        public int Id { get; set; }

        [Display(Name = "Data de validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string DtValidade { get; set; }

        [Display(Name = "Funcionário")]
        public string NomeFunc { get; set; }

        [Display(Name = "Posto de Trabalho")]
        public string NomePostoTrab { get; set; }

        public int IdFunc { get; set; }
        public int IdPostoTrab { get; set; }
    }
}

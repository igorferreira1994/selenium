using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDomain.Domain
{
    public class Dados
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Area { get; set; }
        public string Autor { get; set; }
        public string Publicacao { get; set; }
        public string Descricao { get; set; }
    }
}

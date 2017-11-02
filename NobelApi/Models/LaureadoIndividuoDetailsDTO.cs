using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelApi.Models
{
    public class LaureadoIndividuoDetailsDTO
    {
        public int LaureadoId { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataNascimento { get; set; }
        public Nullable<System.DateTime> DataMorte { get; set; }
        public string Sexo { get; set; }
        public string Picture { get; set; }
        public string Thumbnail { get; set; }
        public virtual CidadeDTO CidadeNascimento { get; set; }
        public virtual CidadeDTO CidadeMorte { get; set; }
        public virtual ICollection<PremioNobelDTO> PremioNobel { get; set; }
        public virtual ICollection<FiliacaoDTO> Filiacao { get; set; }

    }
}
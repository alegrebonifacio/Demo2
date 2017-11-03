using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelApi.Models
{

    public partial class PremioNobelDetailsDTO
    {
        public int PremioNobelId { get; set; }
        public int Ano { get; set; }
        public string Titulo { get; set; }
        public string Motivacao { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        public virtual ICollection<LaureadoIndividuoDTO> Individuo { get; set; }
        public virtual ICollection<LaureadoOrganizacaoDTO> Organizacao { get; set; }
    }
}
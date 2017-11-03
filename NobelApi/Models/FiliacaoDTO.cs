using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelApi.Models
{
    public partial class FiliacaoDTO
    {
        public int FiliacaoId { get; set; }
        public string Nome { get; set; }

        public virtual CidadeDTO Cidade { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelApi.Models
{
    public partial class CidadeDTO
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public PaisDTO Pais { get; set; }
    }
}
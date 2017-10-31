using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{

    [MetadataType(typeof(PremioNobelMetadata))]
    public partial class PremioNobel { }
    [MetadataType(typeof(CategoriaMetadata))]
    public partial class Categoria { }

}
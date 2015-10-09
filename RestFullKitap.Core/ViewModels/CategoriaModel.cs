using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFullKitap.Core.ViewModels
{
    public class CategoriaModel
    {
        [Required]
        public long Id { get; set; }
        
        public string Nome { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bie.evgestao.ui.viewmodels
{
    class CargoViewmodel
    {
        [Key]
        public int id_cargo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        public string Tipo { get; set; }


    }
}

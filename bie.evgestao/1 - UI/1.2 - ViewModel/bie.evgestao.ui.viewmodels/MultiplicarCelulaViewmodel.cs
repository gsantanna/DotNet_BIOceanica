using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bie.evgestao.ui.viewmodels
{
    public class MultiplicarCelulaViewmodel
    {

        [Required(ErrorMessage = "Célula origem não definida")]
        [Display(Name = "Célula de origem")]
        public int id_origem { get; set; }

        [Required(ErrorMessage = "Informe o coordenador da nova celula")]
        [Display(Name = "Coordenador")]
        public int id_coordenador { get; set; }

        [Display(Name = "Supervisor")]
        public int? id_supervisor { get; set; }

        [Required(ErrorMessage = "Pelo menos um membro deve ser selecionado")]
        public int[] Membros { get; set; }


    }


    public class MultiplicarCelulasDisponiveisViewmodel
    {
        public string NomeCoordenador { get; set; }
        public int id_celula { get; set; }
        public string NomeSupervisor { get; set; }
    }
}

using System.Collections.Generic;
using bie.evgestao.domain.Enums;

namespace bie.evgestao.domain.Entities
{
    /// <summary>
    /// Proxy de usuário para o usuário do Asp NET Identity, esta classe mantém o id_usuário entre as duas tabelas (sistema e asp net identity) 
    /// </summary>
    public class Usuario
    {
        //string para sincronizar com o login 
        public string id_usuario { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public string Telefone { get; set; }
        public string Telefone2 { get; set; }      

        public string Email { get; set; }

    }
}
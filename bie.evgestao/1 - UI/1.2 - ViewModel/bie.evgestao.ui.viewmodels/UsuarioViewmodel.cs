using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using bie.evgestao.domain.Enums;

namespace bie.evgestao.ui.viewmodels
{
    public class UsuarioViewmodel
    {
        public UsuarioViewmodel()
        {
            Roles = new List<string>();
        }
        //string para sincronizar com o login 
        public string id_usuario { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O limite para o campo {0} é  de {1} caracteres")]
        [MinLength(5, ErrorMessage = "Favor preencher no mínimo {1} caracteres")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }



        [Phone(ErrorMessage = "Favor preencher um telefone válido")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        [Phone(ErrorMessage = "Favor preencher um telefone válido")]
        public string Telefone2 { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Favor preencher um e-mail válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }



     


        public List<string> Roles { get; set; }

        public TipoUsuario Tipo
        {
            get
            {               
                //Secretaria, Financeiro, Pastor, Conselho, Lider, Supervisor, Administrador, Superadmin
                if (Roles.Contains("Superadmin")) return TipoUsuario.Superadmin;
                else if (Roles.Contains("Administrador")) return TipoUsuario.Administrador;
                else if (Roles.Contains("Supervisor")) return TipoUsuario.Supervisor;
                else if (Roles.Contains("Lider")) return TipoUsuario.Lider;
                else if (Roles.Contains("Conselho")) return TipoUsuario.Conselho;
                else if (Roles.Contains("Pastor")) return TipoUsuario.Pastor;
                else if (Roles.Contains("Financeiro")) return TipoUsuario.Financeiro;
                else if (Roles.Contains("Secretaria")) return TipoUsuario.Secretaria;
                else throw new Exception("Permissões não configuradas");
            }
        }

        public string TipoDesc => Tipo.ToString();


        #region "CRIAR E EDITAR"

        [Required]
        [Display(Name = "Tipo de Usuário")]
        public TipoUsuario Funcao { get; set; }

        [Display(Name = "Senha")]
        [StringLength(100, ErrorMessage = "A {0} deve ter no mínimo {2} caracteres.", MinimumLength = 6)]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Compare("Senha", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmarSenha { get; set; }


        #endregion











    }
}

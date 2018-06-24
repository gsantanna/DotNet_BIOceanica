using System;
using System.ComponentModel;

namespace bie.evgestao.domain.Enums
{

    #region Identity 
    public enum TipoUsuario
    {
        Secretaria, Financeiro, Pastor, Conselho, Lider, Supervisor, Administrador, Superadmin, NAO_CONFIGURADO
    }
    #endregion

    #region Infra.Comm

    public enum RespostaNotificacao
    {
        Sucesso, Falha
    }

    public enum TipoEntregaNotificacao
    {
        EmailTemplate, Email, SMS, NetSend
    }

    #endregion

    #region Pessoa

    public enum SexoPessoa
    {
        M = 1,
        F = 2
    }

    public enum SituacaoPessoa
    {
        [Description("Comungante")]
        COMUNGANTE = 1,
        [Description("Não comungante")]
        NAOCOMUNGANTE = 2,
        [Description("Visitante")]
        VISITANTE = 3,
        [Description("Fora de sede")]
        FORADESEDE = 4,
        [Description("Outros")]
        OUTROS = -1

        //Comungante, Não-Comungante, Visitante, Fora de Sede.
    }

    public enum FuncaoPessoa
    {
        /*Pastor, Presbítero, Líder de Célula, Supervisor de Célula, Líder de Ministério.*/

        [Description("Pastor")]
        PASTOR = 1,
        [Description("Presbítero")]
        PRESBITERO = 2,
        [Description("Líder de Célula")]
        LIDER_CELULA = 3,
        [Description("Supervisor de Célula")]
        SUPERVISOR_CELULA = 4,
        [Description("Líder de Ministério")]
        LIDER_MINISTERIO = 5,
        OUTROS = -1

    }

    public enum EstadoCivilPessoa
    {
        [Description("Solteiro (a)")]
        SOLTEIRO = 1,
        [Description("Casado (a)")]
        CASADO = 2,
        [Description("Viúvo (a)")]
        VIUVO = 3,
        [Description("Divorciado")]
        DIVORCIADO = 4
    }

    public enum TipoSanguineoPessoa
    {
        [Description("A+")]
        A_POS = 1,
        [Description("A-")]
        A_NEG = 2,
        [Description("B+")]
        B_POS = 3,
        [Description("B-")]
        B_NEG = 4,
        [Description("AB+")]
        AB_POS = 5,
        [Description("AB-")]
        AB_NEG = 6,
        [Description("O+")]
        O_POS = 7,
        [Description("O-")]
        O_NEG = 8
    }

    public enum TipoEntradaPessoa
    {
        [Description("Batismo")]
        BATISMO = 1,
        [Description("Batismo e Profissão de Fé")]
        BATISMO_PROFISSAO = 2,
        [Description("Batismo Infantil")]
        BATISMO_INFANTIL = 3,
        [Description("Profissão de Fé")]
        PROFISSAO_FE = 4,
        [Description("Transferência")]
        TRANSFERENCIA = 5,
        [Description("Juristição Ex-officio")]
        JURISDICAO_EX_OFFICIO = 6
    }

    /*Carta de Transferência, Exclusão a Pedido, Exclusão por Ausência, Exclusão por Disciplina, Jurisdição a Pedido, Falecimento.*/
    public enum TipoSaidaPessoa
    {
        [Description("Carta de Transferência")]
        CARTA_TRANSFERENCIA = 1,
        [Description("Exclusão a Pedido")]
        EXCLUSAO_PEDIDO = 2,
        [Description("Exclusão por Ausência")]
        EXCLUSAO_AUSENCIA = 3,
        [Description("Exclusão por Disciplina")]
        EXCLUSAO_DISCIPLINA = 4,
        [Description("Juristição a Pedido")]
        JURISTICAO_PEDIDO = 5,
        [Description("Falecimento")]
        FALECIMENTO = 6

    }
    #endregion

    #region Extensões
    public static class Extensions
    {
        public static string ToDescriptionString(this Enum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
    #endregion


}

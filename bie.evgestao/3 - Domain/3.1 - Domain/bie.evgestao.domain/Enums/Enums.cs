using System;
using System.Collections.Generic;
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

    /*Não Consta, Cônjuge, Filho, Filha, Pai, Mãe, Avô, Avó, Irmão, Irmã, Neto, Neta, Tio, Tia, Sobrinho, Sobrinha, Primo, Prima*/
    public enum GrauParentesco
    {
        [Description("Não consta")]
        NAO_CONSTA = -1,
        [Description("Cônjuge")]
        CONJUGE = 1,
        [Description("Filho(a)")]
        FILHO = 2,
        [Description("Pai")]
        PAI = 3,
        [Description("Mãe")]
        MAE = 4,
        [Description("Avô/Avó")]
        AVO = 5,
        [Description("Irmão(a)")]
        IRMAO = 6,
        [Description("Neto(a)")]
        NETO = 7,
        [Description("Tio(a)")]
        TIO = 8,
        [Description("Sobrinho(a)")]
        SOBRINHO = 9,
        [Description("Primo(a)")]
        PRIMO = 10
    }

    #endregion


    #region Celula
    public enum TipoCelula
    {
        [Description("Adulto")]
        ADULTO = 1,
        [Description("GO")]
        GO = 2,
        [Description("UP")]
        UP = 3,
        [Description("Teen")]
        TEEN = 4
    }



    #endregion



    #region Geografia 



    public enum EstadosBrasil
    {
        AC, // Acre
        AL, // Alagoas
        AP, // Amapá
        AM, // Amazonas
        BA, // Bahia
        CE, // Ceará
        DF, // Distrito Federal
        ES, // Espírito Santo
        GO, // Goiás
        MA, // Maranhão
        MT, // Mato Grosso
        MS, // Mato Grosso do Sul
        MG, // Minas Gerais
        PA, // Pará
        PB, // Paraíba
        PR, // Paraná
        PE, // Pernambuco
        PI, // Piauí
        RR, // Roraima
        RO, // Rondônia
        RJ, // Rio de Janeiro
        RN, // Rio Grande do Norte
        RS, // Rio Grande do Sul
        SC, // Santa Catarina
        SP, // São Paulo
        SE, // Sergipe
        TO // Tocantins        
    }






    #endregion



    #region Tempo

    public enum DiasSemana
    {
        [Description("Segunda")]
        SEG = 1,
        [Description("Terça")]
        TER = 2,
        [Description("Quarta")]
        QUA = 3,
        [Description("Quinta")]
        QUI = 4,
        [Description("Sexta")]
        SEX = 5,
        [Description("Sábado")]
        SAB = 6,
        [Description("Domingo")]
        DOM = 0
    }


    #endregion









    #region Extensões
    public static class Extensions
    {
        public static string ToDescriptionString(this Enum val)
        {
            if (val == null) return string.Empty;
            try
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : val.ToString();
            }
            catch
            {
                return val.ToString();
            }

        }






    }







    #endregion



}


namespace bie.evgestao.domain.Enums
{
    public enum SEXO { M, F }

    public enum TipoUsuario
    {
        Secretaria, Financeiro, Pastor, Conselho, Lider, Supervisor, Administrador, Superadmin
    }

    public enum ClassificacaoAlerta
    {
        Informacao, Aviso, Urgente
    }

    public enum RespostaNotificacao
    {
        Sucesso, Falha
    }

    public enum TipoEntregaNotificacao
    {
        EmailTemplate, Email, SMS, NetSend
    }

}

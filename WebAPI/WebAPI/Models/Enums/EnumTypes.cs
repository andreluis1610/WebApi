using System.ComponentModel;

namespace WebAPI.Models.Enums
{
    public enum Profile
    {
        [Description("Administrador")]
        Administrator = 0,
        [Description("Analista de Compras")]
        BusinessAnalyst = 1,
        [Description("Analista Financeiro")]
        FinancialAnalyst = 2,
        [Description("Diretor Financeiro")]
        CFO = 3
    }

    public enum Status
    {
        [Description("Cadastrada")]
        Registred = 1,
        [Description("Aprovada")]
        Approved = 2,
        [Description("Reprovada")]
        Disapproved = 3,
        [Description("Pedente Diretoria")]
        PendingDirectors = 4
    }

    public enum StatusNow
    {
        [Description("Cadastrada")]
        Registred = 1,
        [Description("Aprovada pelo Analista Financeiro")]
        ApprovedByFinancialAnalyst = 2,
        [Description("Aprovada pelo Diretor Financeiro")]
        ApprovedByCFO = 3,
        [Description("Reprovada pelo Analista Financeiro")]
        DisapprovedByFinancialAnalyst = 4,
        [Description("Reprovada pelo Diretor Financeiro")]
        DisapprovedByCFO = 5,
        [Description("Proposta Expirada")]
        Expired = 6
    }

    public enum TimeConfig
    {
        [Description("Hora")]
        Hour = 1,
        [Description("Dia")]
        Day = 2
    }

    public enum ActionHistoric
    {
        [Description("Proposta Cadastrada")]
        Registred = 1,
        [Description("Proposta Editada")]
        Edited = 2,
        [Description("Proposta aprovada pelo Analista Financeiro")]
        ApprovedByFinancialAnalyst = 3,
        [Description("Proposta aprovada pelo Diretor Financeiro")]
        ApprovedByCFO = 4,
        [Description("Proposta reprovada pelo Analista Financeiro")]
        DisapprovedByFinancialAnalyst = 5,
        [Description("Proposta reprovada pelo Diretor Financeiro")]
        DisapprovedByCFO = 6,
        [Description("Proposta Expirada")]
        Expired = 7
    }
}
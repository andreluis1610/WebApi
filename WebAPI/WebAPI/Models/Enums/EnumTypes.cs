using System.ComponentModel;

namespace WebAPI.Models.Enums
{
    public enum Profile
    {
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
        DisapprovedByCFO = 5
    }

    public enum TimeConfig
    {
        [Description("Hora")]
        Hour = 1,
        [Description("Dia")]
        Day = 2
    }
}
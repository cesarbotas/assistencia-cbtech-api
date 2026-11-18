namespace CBTech.Domain.Enums;

public enum WorkOrderStatus
{
    Recebido = 1,
    EmDiagnostico = 2,
    AguardandoAprovacao = 3,
    EmReparo = 4,
    AguardandoPeca = 5,
    Concluido = 6,
    Entregue = 7,
    Cancelado = 8
}

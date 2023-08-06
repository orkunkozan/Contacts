using System.ComponentModel;

namespace Rice.Core.Enums
{
    public enum ReportStateType
    {
        [Description("İstendi")]
        Requested,
        [Description("İşlem Yapılıyor")]
        Processing,
        [Description("Tamanmlandı")]
        Completed
    }
}

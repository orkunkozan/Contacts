using System.ComponentModel;

namespace Rice.Core.Enums
{
    public enum ContactType
    {
        [Description("Telefon Numarası")]
        PhoneNumber,
        [Description("E-Posta")]
        Email,
        [Description("Konum")]
        Location
    }
}

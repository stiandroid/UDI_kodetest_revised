namespace UDI_kodetest_revised.Models.DTO;

public class VedtakDTO
{
    public string Authority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime? GyldigFra { get; set; }
    public DateTime? GyldigTil { get; set; }
}

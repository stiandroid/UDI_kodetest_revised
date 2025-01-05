using System.Text.Json.Serialization;

namespace UDI_kodetest_revised.Models.Entity;

public class Sak
{
    [JsonPropertyName("Sakid")]
    public required string SakId { get; set; }
    public required string RefNo { get; set; }

    [JsonPropertyName("Recno")]
    public int RecNo { get; set; }

    public bool SendtSms { get; set; }

    public Person? Kontakt { get; set; }
    public Person? Fullmektig { get; set; }

    [JsonPropertyName("Søker")]
    public Person? Soeker { get; set; }

    public Vedtak? Vedtak { get; set; }
}

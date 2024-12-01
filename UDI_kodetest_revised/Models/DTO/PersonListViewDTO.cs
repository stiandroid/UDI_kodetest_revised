namespace UDI_kodetest_revised.Models.DTO;

public class PersonListViweDTO
{
    public string Fornavn { get; set; } = string.Empty;
    public string Etternavn { get; set; } = string.Empty;
    public string Mellomnavn { get; set; } = string.Empty;
    public DateTime Fødselsdato { get; set; }
    public string Land { get; set; } = string.Empty;
}

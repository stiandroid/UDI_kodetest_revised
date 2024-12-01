using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace UDI_kodetest_revised.Models.Entity;

public class Person
{
    public Guid Id { get; set; }
    public string Epost { get; set; } = string.Empty;
    public string ExternalIdField { get; set; } = string.Empty;
    public required string Fornavn { get; set; }
    public required string Etternavn { get; set; }
    public string Mellomnavn { get; set; } = string.Empty;
    public required string Mobilnummer { get; set; }
    public string Personnummer { get; set; } = string.Empty;
    public required string Reisedokumentnummer { get; set; }
    public required DateTime Fødselsdato { get; set; }
    public string Adresse { get; set; } = string.Empty;
    public string Poststed { get; set; } = string.Empty;
    public string Postnummer { get; set; } = string.Empty;
    public string Land { get; set; } = string.Empty;
}

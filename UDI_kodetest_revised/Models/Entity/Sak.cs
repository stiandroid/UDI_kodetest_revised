namespace UDI_kodetest_revised.Models.Entity;

public class Sak
{
    public Guid Id { get; set; }
    public required string RefNo { get; set; }
    public int Recno { get; set; }
    public required string Sakid { get; set; }
    public bool SendtSms { get; set; }

    public Guid? KontaktId { get; set; }
    public Person? Kontakt { get; set; }

    public Guid? FullmektigId { get; set; }
    public Person? Fullmektig { get; set; }

    public Guid? SøkerId { get; set; }
    public Person? Søker { get; set; }

    public Guid? VedtaksId { get; set; }
    public Vedtak? Vedtak { get; set; }
}

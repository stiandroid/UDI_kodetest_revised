namespace UDI_kodetest_revised.Models.DTO;

public class SakDTO
{
    public required string RefNo { get; set; }
    public int Recno { get; set; }
    public required string Sakid { get; set; }
    public bool SendtSms { get; set; }
    public PersonDetailsViewDTO? Kontakt { get; set; }
    public PersonDetailsViewDTO? Fullmektig { get; set; }
    public PersonDetailsViewDTO? Søker { get; set; }
    public VedtakDTO? Vedtak { get; set; }
}

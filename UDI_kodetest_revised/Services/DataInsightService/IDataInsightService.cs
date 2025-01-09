namespace UDI_kodetest_revised.Services.DataInsightService;

public interface IDataInsightService
{
    Task<List<Sak>> HentAlleSaker();
    Task<List<Vedtak>> HentAlleVedtak();
    Task<List<Person>> HentAllePersoner();
}

namespace UDI_kodetest_revised.Services.DataInsightService;

public class DataInsightService(AppDbContext context) : IDataInsightService
{
    private readonly AppDbContext context = context;

    public async Task<List<Sak>> HentAlleSaker() => await context.Saker.ToListAsync();
    public async Task<List<Vedtak>> HentAlleVedtak() => await context.Vedtak.ToListAsync();
    public async Task<List<Person>> HentAllePersoner() => await context.Personer.ToListAsync();
}

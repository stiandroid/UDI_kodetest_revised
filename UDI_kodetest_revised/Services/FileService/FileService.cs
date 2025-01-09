using System.Text.Json;

namespace UDI_kodetest_revised.Services.FileService;

public class FileService(AppDbContext dbContext) : IFileService
{
    private readonly long _maxFileSize = 1024 * 1024; // 1 MB

    public async Task<ServiceResult> ImportFileAsync(IBrowserFile file)
    {
        var result = new ServiceResult();

        try
        {
            using MemoryStream memoryStream = new();
            await file.OpenReadStream(_maxFileSize)
                .CopyToAsync(memoryStream);

            memoryStream
                .Seek(0, SeekOrigin.Begin);

            await ProcessFileAsync(memoryStream, result);
        }
        catch (Exception ex)
        {
            result.Errors.Add($"Filen '{file.Name}' forårsaket feil: {ex.Message}");
        }

        result.Success = result.Errors.Count == 0;
        return result;
    }

    private async Task ProcessFileAsync(Stream fileStream, ServiceResult result)
    {
        try
        {
            var saker = await JsonSerializer.DeserializeAsync<List<Sak>>(fileStream);

            if (saker != null)
            {
                foreach (var sak in saker)
                {
                    if (sak.Soeker != null) await AddOrUpdatePersonAsync(sak.Soeker);
                    if (sak.Fullmektig != null) await AddOrUpdatePersonAsync(sak.Fullmektig);
                    if (sak.Kontakt != null) await AddOrUpdatePersonAsync(sak.Kontakt);

                    var existingSak = await dbContext.Saker
                        .FirstOrDefaultAsync(s => s.SakId == sak.SakId);

                    if (existingSak == null)
                    {
                        await dbContext.Saker.AddAsync(sak);
                    }
                }

                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            result.Errors.Add($"Feil ved serialisering av filen: {ex.Message}");
        }
    }

    private async Task AddOrUpdatePersonAsync(Person person)
    {
        var trackedPerson = dbContext.Personer.Local
            .FirstOrDefault(p => p.Personnummer == person.Personnummer);

        if (trackedPerson != null)
        {
            UpdatePersonProperties(trackedPerson, person);
        }
        else
        {
            var existingPerson = await dbContext.Personer
                .FirstOrDefaultAsync(p => p.Personnummer == person.Personnummer);

            if (existingPerson != null)
            {
                UpdatePersonProperties(existingPerson, person);
            }
            else
            {
                await dbContext.Personer.AddAsync(person);
            }
        }
    }

    private void UpdatePersonProperties(Person existingPerson, Person newPerson)
    {
        existingPerson.Reisedokumentnummer = newPerson.Reisedokumentnummer;
        existingPerson.Fornavn = newPerson.Fornavn;
        existingPerson.Etternavn = newPerson.Etternavn;
        existingPerson.Mellomnavn = newPerson.Mellomnavn;
        existingPerson.Epost = newPerson.Epost;
        existingPerson.Mobilnummer = newPerson.Mobilnummer;
        existingPerson.Fødselsdato = newPerson.Fødselsdato;
        existingPerson.Adresse = newPerson.Adresse;
        existingPerson.Poststed = newPerson.Poststed;
        existingPerson.Postnummer = newPerson.Postnummer;
        existingPerson.Land = newPerson.Land;
    }
}

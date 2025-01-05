using System.Text.Json;

namespace UDI_kodetest_revised.Services.FileService;

public class FileService(AppDbContext dbContext, IConfiguration config) : IFileService
{
    private readonly string _rootFolder = config.GetValue<string>("FileStorage") ?? string.Empty;
    private readonly long _maxFileSize = 1024 * 1024; // 1 MB

    public async Task<ServiceResult> ImportFilesAsync(IEnumerable<IBrowserFile> files)
    {
        var result = new ServiceResult();

        foreach (var file in files)
        {
            try
            {
                string newFilename = Path.ChangeExtension(
                    Path.GetRandomFileName(),
                    Path.GetExtension(file.Name));

                string path = Path.Combine(_rootFolder, newFilename);
                Directory.CreateDirectory(_rootFolder);

                await using FileStream fileStream = new(path, FileMode.Create);
                await file.OpenReadStream(_maxFileSize).CopyToAsync(fileStream);

                await ProcessFileAsync(fileStream, result);
            }
            catch (Exception ex)
            {
                result.Errors.Add($"Filen '{file.Name}' forårsaket feil: {ex.Message}");
            }
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

                    await dbContext.Saker.AddAsync(sak);
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
        var existingPerson = await dbContext.Personer
            .FirstOrDefaultAsync(p => p.Personnummer == person.Personnummer);

        if (existingPerson != null)
        {
            existingPerson.Reisedokumentnummer = person.Reisedokumentnummer;
            existingPerson.Fornavn = person.Fornavn;
            existingPerson.Etternavn = person.Etternavn;
            existingPerson.Mellomnavn = person.Mellomnavn;
            existingPerson.Epost = person.Epost;
            existingPerson.Mobilnummer = person.Mobilnummer;
            existingPerson.Fødselsdato = person.Fødselsdato;
            existingPerson.Adresse = person.Adresse;
            existingPerson.Poststed = person.Poststed;
            existingPerson.Postnummer = person.Postnummer;
            existingPerson.Land = person.Land;

            dbContext.Personer.Update(existingPerson);
        }
        else
        {
            await dbContext.Personer.AddAsync(person);
        }
    }
}

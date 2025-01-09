namespace UDI_kodetest_revised.Services.FileService;

public interface IFileService
{
    Task<ServiceResult> ImportFileAsync(IBrowserFile file);
}
using UDI_kodetest_revised.Models;

namespace UDI_kodetest_revised.Services.FileService;

public interface IFileService
{
    Task<ServiceResult> ImportFilesAsync(IEnumerable<IBrowserFile> files);
}
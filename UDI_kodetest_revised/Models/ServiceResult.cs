namespace UDI_kodetest_revised.Models;

public class ServiceResult
{
    public bool Success { get; set; }
    public List<string> Errors { get; set; } = [];
}

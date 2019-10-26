namespace SympliSEOSolution.InterfaceLibrary
{
    public interface ISeoRequest
    {
        string SearchText { get; set; }
        string UrlFilter { get; set; }
        int NumberOfRecords { get; set; }
    }
}
namespace SympliSEOSolution.InterfaceLibrary
{
    public interface ISeoRequest
    {
        string SearchText { get; set; }
        string SearchResultFilter { get; set; }
    }
}
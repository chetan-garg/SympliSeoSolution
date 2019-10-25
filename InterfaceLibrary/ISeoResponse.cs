namespace SympliSEOSolution.InterfaceLibrary
{
    public interface ISeoResponse
    {
        string TextSearched { get; set; }
        string FilterText { get; set; }
        int PositionNumber { get; set; }
    }
}
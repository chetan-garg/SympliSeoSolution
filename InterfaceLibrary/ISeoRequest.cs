using System.ComponentModel.DataAnnotations;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface ISeoRequest
    {
        [Required]
        string SearchText { get; set; }
        [Required]
        string UrlFilter { get; set; }
        int NumberOfRecords { get; set; }
        [Required]
        string SeoEngineType { get; set; }
    }
}
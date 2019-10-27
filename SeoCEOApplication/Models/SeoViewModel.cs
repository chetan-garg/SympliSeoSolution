using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeoCEOApplication.Models
{
    public class SeoViewModel
    {
        [Required]
        public string SearchText { get; set; }
        [Required]
        public string UrlFilter { get; set; }
        public string PositionNumbers { get; set; }
        public string SeoEngineType { get; set; }
    }
}

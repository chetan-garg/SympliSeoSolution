using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface IUrlConstructorUtility
    {
        string ConstructUrl(string baseUrl, int numberOfRecords, string textToSearch);
    }
}

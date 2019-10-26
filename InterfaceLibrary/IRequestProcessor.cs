using System.Net;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface IRequestProcessor
    {
        WebResponse ExecuteWebRequest(WebRequest request);
    }
}
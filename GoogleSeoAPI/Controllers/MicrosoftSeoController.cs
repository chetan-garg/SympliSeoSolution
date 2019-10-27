using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SympliSEOSolution.InterfaceLibrary;
using SympliSEOSolution.SeoEntitiesImplementations;
using SympliSEOSolution.Workers;

namespace GoogleSeoAPI.Controllers
{
    [Route("microsoftseo")]
    [ApiController]
    public class MicrosoftSeoController : ControllerBase
    {
        private readonly ILogger<MicrosoftSeoController> _logger;
        private readonly ISeoOrchestration _orchester;
        
        public MicrosoftSeoController(ILogger<MicrosoftSeoController> logger, ISeoOrchestration orchestration)
        {
            _logger = logger;
            _orchester = orchestration;
        }
        // GET: api/MicrosoftSeo
        [HttpGet]
        public SeoResponse Get([FromBody] SeoRequest request)
        {
            if (request == null)
            {
                _logger.LogError("The request object is null. Please check the JSON request.");
                return null;
            }
            return (SeoResponse)_orchester.GetUrlPositionsFrom(request);
            
        }        
    }
}

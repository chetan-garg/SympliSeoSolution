using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SympliSEOSolution.InterfaceLibrary;
using SympliSEOSolution.SeoEntitiesImplementations;

namespace GoogleSeoAPI.Controllers
{
    [ApiController]
    [Route("googleseo")]
    public class GoogleSeoController : ControllerBase
    {
        private readonly ILogger<GoogleSeoController> _logger;
        private readonly ISeoOrchestration _orchester;

        public GoogleSeoController(ILogger<GoogleSeoController> logger, ISeoOrchestration orchestration)
        {
            _logger = logger;
            _orchester = orchestration;
        }

        [HttpGet]
        public string Get(SeoRequest request)
        {
            return _orchester.GetUrlPositionsFromGoogle(request).PositionNumbers;
        }
    }
}

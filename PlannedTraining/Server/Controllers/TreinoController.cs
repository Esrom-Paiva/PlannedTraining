using Microsoft.AspNetCore.Mvc;
using PlannedTraining.Server.Interfaces;

namespace PlannedTraining.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinoController : ControllerBase
    {
        private readonly ITreinoService _treinoService;

        public TreinoController(ITreinoService treinoService)
        {
            _treinoService = treinoService;
        }

    }
}

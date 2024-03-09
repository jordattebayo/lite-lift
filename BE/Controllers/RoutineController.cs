using BE.DataAccess;
using BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly ILogger _logger;

        public RoutineController(IConfiguration configuration, ILogger<Routine> logger, IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost(Name = "AddRoutine")]
        public Guid AddRoutine(Routine routine)
        {
            var sid = _dataAccessProvider.AddRoutine(routine);
            return sid;
        }
        [HttpPut(Name = "UpdateRoutine")]
        public void UpdateRoutine(Routine routine)
        {
            _dataAccessProvider.UpdateRoutine(routine.Id, routine);

        }
        [HttpDelete(Name = "DeleteRoutine")]
        public void DeleteRoutine(Guid sid)
        {
            _dataAccessProvider.DeleteRoutine(sid);
        }

        [HttpGet(Name = "GetAllRoutines")]
        public IEnumerable<Routine> GetAllRoutines()
        {
            var routines = _dataAccessProvider.GetAllRoutines();
            return routines;
        }
    }
}

using BE.DataAccess;
using BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly ILogger _logger;

        public SetController(IConfiguration configuration, ILogger<Set> logger, IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost(Name = "AddSet")]
        public Guid AddSet(Set set)
        {
            var sid = _dataAccessProvider.AddSet(set);
            return sid;
        }
        [HttpPut(Name = "UpdateSet")]
        public void UpdateSet(Set set)
        {
            _dataAccessProvider.UpdateSet(set.Sid, set);

        }
        [HttpDelete(Name = "DeleteSet")]
        public void DeleteWorkout(Guid sid)
        {
            _dataAccessProvider.DeleteWorkout(sid);
        }

        [HttpGet(Name = "GetAllSets")]
        public IEnumerable<Set> GetAllSets()
        {
            var sets = _dataAccessProvider.GetAllSets();
            return sets;
        }
    }
}

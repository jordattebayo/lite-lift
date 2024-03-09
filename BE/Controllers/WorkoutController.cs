using BE.DataAccess;
using BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly ILogger _logger;

        public WorkoutController(IConfiguration configuration, ILogger<Workout> logger, IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost(Name = "AddWorkout")]
        public Guid AddWorkout(Workout workout)
        {
            var sid = _dataAccessProvider.AddWorkout(workout);
            return sid;
        }
        [HttpPut(Name = "UpdateWorkout")]
        public void UpdateWorkout(Workout workout)
        {
            _dataAccessProvider.UpdateWorkout(workout.Id, workout);
            
        }
        [HttpDelete(Name = "DeleteWorkout")]
        public void DeleteWorkout(Guid sid)
        {
           _dataAccessProvider.DeleteWorkout(sid);
        }

        [HttpGet(Name = "GetAllWorkouts")]
        public IEnumerable<Workout> GetAllWorkouts()
        {
            var workouts = _dataAccessProvider.GetAllWorkouts();
            return workouts;
        }
    }
}

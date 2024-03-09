using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using BE.DataAccess;
using BE.Models;
using System.Net;

namespace BE.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly ILogger _logger;

        public UserController(IConfiguration configuration, ILogger<User> logger, IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost(Name = "AddUser")]
        public Guid AddUser(User workout)
        {
            var sid = _dataAccessProvider.AddUser(workout);
            return sid;
        }
        [HttpPut(Name = "UpdateUser")]
        public void UpdateUser(User user)
        {
            _dataAccessProvider.UpdateUser(user.Id, user);

        }
        [HttpDelete(Name = "DeleteUser")]
        public void DeleteUser(Guid sid)
        {
            _dataAccessProvider.DeleteUser(sid);
        }
        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            var users = _dataAccessProvider.GetAllUsers();
            return users;
        }
        

    }
}

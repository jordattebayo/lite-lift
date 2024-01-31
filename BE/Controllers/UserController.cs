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
    [Route("[controller]")]
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

        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            var users = _dataAccessProvider.GetAllUsers();
            return users;
        }
        

    }
}

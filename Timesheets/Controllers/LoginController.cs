using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Stripe.Issuing;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;


namespace Timesheets.Controllers
{
    public class LoginController :TimesheetBaseController
    {
        private readonly IUsersManager _userManager;
        private readonly ILoginManager _loginManager;

        public LoginController(ILoginManager loginManager, IUsersManager userManager)
        {
            _loginManager = loginManager;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.GetUser(request);

            if (user == null)
            {
                return Unauthorized();
            }

            var loginResponse = await _loginManager.Authenticate(user);

            return Ok(loginResponse);
        }
    }
}


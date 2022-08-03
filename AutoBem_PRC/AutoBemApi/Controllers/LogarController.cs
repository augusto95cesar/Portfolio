using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoBemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LogarController : ControllerBase
    {
        [HttpGet("Token")]
        [AllowAnonymous]
        public ActionResult<object> TokenUsuario()
        {
            var client = new HttpClient();
            var disco = Task.Run(async () => await client.GetDiscoveryDocumentAsync("https://localhost:5001")).GetAwaiter().GetResult();
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return BadRequest();
            }

            var tokenResponse = Task.Run(async () => await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "autobem",
                ClientSecret = "123456",
                Scope = "AutoBemApi"
            })).GetAwaiter().GetResult();

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return BadRequest();
            }

            Console.WriteLine(tokenResponse.Json);
            return Ok(new { Token = tokenResponse.AccessToken });
        }

        [HttpGet("Claims")]

        public IActionResult GetClaims()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }   
}

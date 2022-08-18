using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemoApp.Filters;
using ApiDemoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IHomeServices homeServices;
		public HomeController(IHomeServices _homeServices)
		{
                homeServices = _homeServices;
		}

        [HttpGet]
        public string Index(string id)
        {
            if (id != null)
            {
                return "Received " + id.ToString();
            }
            else
            {
                return "Received nothing";
            }
        }

        [HttpPost]
        [ResponseHeader("Filter-Header", "Filter Value")]
        public string GetFullName([FromQuery] string firstname,  [FromQuery] string lastname)
        {
            return homeServices.FullName(firstname,lastname);
        }
    }
}

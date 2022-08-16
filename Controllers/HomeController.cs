using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
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
    }
}

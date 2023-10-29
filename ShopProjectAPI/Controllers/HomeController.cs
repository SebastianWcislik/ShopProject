﻿using Microsoft.AspNetCore.Mvc;

namespace ShopProjectAPPAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestASync()
        {
            return Ok("asd");
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok("asd");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;

namespace bpssgestion
{

    [ApiController]
    [Route("[controller]")]
    public class MensajeController : Controller
    {
        [Route("gracias")]
        public IActionResult Gracias()
        {
         return View();
        }
    }
}
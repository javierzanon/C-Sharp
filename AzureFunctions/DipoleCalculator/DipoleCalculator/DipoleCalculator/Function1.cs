using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DipoleCalculator
{
    public static class Dipole
    {
        [FunctionName("Dipole")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            double frequencyParameter = 0;

            if (!string.IsNullOrWhiteSpace(req.Query["frequency"]) )
            {
                frequencyParameter = double.Parse(req.Query["frequency"]);
            }
            
            string output;

            if (frequencyParameter == 0)
            {
                output = "You should specify the frequency in MHZ of the dipole";
            }
            else
            {
                output = "You selected the frequency " + frequencyParameter.ToString() + " MHZ. The lenght of each sideo of the dipole antenna is: " + dipoleLength(frequencyParameter).ToString() + " M.";
            }
            
            return new OkObjectResult(output);
        }
        private static double dipoleLength(double frequency)
        {
            double factor = 142.5;
            double result = factor / frequency / 2;
            return Math.Round(result, 4);
        }
    }
    
}

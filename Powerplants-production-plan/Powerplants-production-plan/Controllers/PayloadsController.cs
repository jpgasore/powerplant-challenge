using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Powerplants_production_plan.Models;

namespace Powerplants_production_plan.Controllers
{
  
    [Route("api/productionplan")]
    [ApiController]
    public class PayloadsController : ControllerBase
    {
        private readonly ILogger<PayloadsController> _logger;

        public PayloadsController(ILogger<PayloadsController> logger)
        {
            _logger = logger;
        }
        [HttpGet, Route("payload")]   
        public string  payload()
        {
            string result = string.Empty;
            List<Response> rsps = new List<Response>();
            try
            {
                List<string> filepaths = new List<string>
                {
                 ".../../coding-challenge/example_payloads/payload1.json",
                 ".../../coding-challenge/example_payloads/payload2.json",
                 ".../../coding-challenge/example_payloads/payload3.json"
                };

                List<Load> loads = new List<Load>();
                _logger.LogInformation("Loading json files");
                foreach (string filepath in filepaths)
                {
                    using (StreamReader r = new StreamReader(filepath))
                    {
                        var json = r.ReadToEnd();
                        Load load = (Load)JsonConvert.DeserializeObject<Load>(json);
                        loads.Add(load);
                    }

                }
                _logger.LogInformation("Loading json files ended.");
                _logger.LogInformation("Process the produced power and determinate the merit order");


                foreach (Load ld in loads)
                {

                    List<Powerplant> pwps = ld.powerplants;
                    Fuel fs = ld.fuels;
                    foreach (Powerplant pwp in pwps)
                    {
                        double power_generated = 0.0;

                        if (fs.Wind != 0)
                        {
                            power_generated = 0.1 * (fs.Wind * pwp.Pmax) / 100;
                        }
                        Response rsp = new Response
                        {
                            Name = pwp.Name,
                            P = power_generated
                        };
                        rsps.Add(rsp);
                    }
                }
                 result = JsonConvert.SerializeObject(rsps);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return result;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Powerplants_production_plan.Models
{
    public class Load
    {
        public string load { get; set; }
        public Fuel fuels { get; set; }
        public List<Powerplant> powerplants { get; set; }
    }
}

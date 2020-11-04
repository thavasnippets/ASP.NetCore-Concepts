using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Components;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjection.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ICalc<double> _calc;

        public ValuesController(ICalc<double> calc)
        {
            _calc = calc;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { _calc.add(1,100).ToString() };
        }

    }
}

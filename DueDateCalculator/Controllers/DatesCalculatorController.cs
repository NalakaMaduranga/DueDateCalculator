using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DueDateCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesCalculatorController : ControllerBase
    {
        [HttpGet]
        public DateTime GetEndDate(DateTime startDate, int daysOfComplete)
        {
            DateTime endDate = new DateTime(2022, 8, 19);
            return endDate;
        }
    }
}

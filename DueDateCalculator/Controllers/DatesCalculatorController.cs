using DueDateCalculator.Services;
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
        private readonly CalculateDateService _calculateDateService;

        public DatesCalculatorController()
        {
            _calculateDateService = new CalculateDateService();
        }
        [HttpGet]
        public DateTime GetEndDate(DateTime startDate, int daysOfComplete)
        {
            DateTime endDate = _calculateDateService.CalculateEndDate(startDate, daysOfComplete);
            return endDate;
        }
    }
}

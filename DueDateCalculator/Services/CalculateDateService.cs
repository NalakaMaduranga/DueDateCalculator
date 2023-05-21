using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DueDateCalculator.Services
{
    public class CalculateDateService
    {
        public DateTime CalculateEndDate(DateTime startDate, int workingDays)
        {
            string taskStartDate = startDate.ToString("dd/MM/yyyy");
            DateTime splitedTaskStartDate = DateTime.ParseExact(taskStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime modifiedTaskStartDate = new DateTime(splitedTaskStartDate.Year, splitedTaskStartDate.Month, splitedTaskStartDate.Day);
            List<DateTime> holidayDates = new List<DateTime>
            {
                new DateTime(2022, 8, 23)
            };

            int totalDays = 0;
            while (workingDays > 0)
            {
                modifiedTaskStartDate = modifiedTaskStartDate.AddDays(1);
                if (modifiedTaskStartDate.DayOfWeek != DayOfWeek.Saturday && modifiedTaskStartDate.DayOfWeek != DayOfWeek.Sunday && !holidayDates.Contains(startDate.Date))
                {
                    workingDays--;
                }
                totalDays++;
            }
            return modifiedTaskStartDate;
        }
    }
}

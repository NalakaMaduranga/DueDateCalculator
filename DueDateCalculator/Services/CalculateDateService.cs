﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DueDateCalculator.Services
{
    public class CalculateDateService
    {
        public string  CalculateEndDate(DateTime startDate, int workingDays)
        {
            string jsonResult = string.Empty;
            try
            {
                if(startDate != DateTime.MinValue)
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
                    var result = new { endDate = modifiedTaskStartDate.ToString("dd/MM/yyyy") };
                    jsonResult = JsonConvert.SerializeObject(result);
                }               
            }
            catch(Exception)
            {
                return "Error: Unable to calculate the due date.Please check inputs";
            }
            return jsonResult;
        }
    }
}

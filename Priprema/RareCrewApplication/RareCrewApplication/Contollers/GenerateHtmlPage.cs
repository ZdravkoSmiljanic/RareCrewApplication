using RareCrewApplication.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RareCrewApplication.Contollers
{
    public  class GenerateHtmlPage
    {
        public string GenerateHtmlTable(List<TotalWorkTime> employees)
        {

            string htmlContent = "<html><head><style>table { border-collapse: collapse; width: 100%; }" +
                                 "th, td { border: 1px solid #dddddd; text-align: left; padding: 8px; }" +
                                 "th { background-color: #f2f2f2; }</style></head><body><table>" +
                                 "<tr><th>Name</th><th>Total time</th></tr>";

            foreach (var employee in employees)
            {

                string rowColor = employee.TotalWorkHours < 100 ? "style='background-color: #FFCCCC;'" : "";
                if (employee.EmployeeName == null)
                {
                    htmlContent += $"<tr {rowColor}><td>Unknown employee</td><td>{Math.Round(employee.TotalWorkHours, 3)}</td></tr>";
                }else
                {
                    htmlContent += $"<tr {rowColor}><td>{employee.EmployeeName}</td><td>{Math.Round(employee.TotalWorkHours, 3)}</td></tr>";
                }

            }

            htmlContent += "</table></body></html>";

            return htmlContent;
        }
    }
}

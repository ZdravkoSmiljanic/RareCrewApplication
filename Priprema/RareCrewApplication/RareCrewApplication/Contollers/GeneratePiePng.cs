using RareCrewApplication.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RareCrewApplication.Contollers
{
    public class GeneratePiePng
    {
       public  void GeneratePieChart(List<TotalWorkTime> employeeDataList, string filePath)
        {
            var plt = new ScottPlot.Plot(2000, 1800);

            double[] values = new double[employeeDataList.Count];
            string[] labels = new string[employeeDataList.Count];
            //Problem je sto ovaj ScottPlot ne moze da primi vise od 10 "parcica" charta zbog vidljivosti i citkosti i zato unknown korisnika ne ispisuje lepo
            for (int i = 0; i < values.Length; i++)
            {
                if (employeeDataList[i].EmployeeName != null)
                {
                    values[i] = employeeDataList[i].TotalWorkHours;
                    labels[i] = employeeDataList[i].EmployeeName;
                }
                else
                {
                    values[i] = employeeDataList[i].TotalWorkHours;
                    labels[i] ="unknown";
                }
                
            }

            plt.PlotPie(values, labels);

            plt.SaveFig(filePath);
        }
    }
}

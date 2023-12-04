
using RareCrewApplication.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using RareCrewApplication.Contollers;
using ScottPlot;

namespace RareCrewApplication
{
    public static class Program
    {


        [STAThread]
        static async Task Main()
        {

            //pre pokretanja programa mozete obrisati html stranicu i sliku iz foldera
            GenerateHtmlPage page = new GenerateHtmlPage();
            GeneratePiePng pie = new GeneratePiePng();
            EmpolyeeController controller = new EmpolyeeController();
           
          
            //Dohvatanje podataka sa API-ja
            List<TotalWorkTime> employees1 = await controller.GetEmployeeData();
            //kreiranje stranice sa tabelom
            string html = page.GenerateHtmlTable(employees1);
            string pagePath = "C:\\Users\\User\\Desktop\\Priprema\\RareCrewApplication\\employes.html";
            File.WriteAllText(pagePath, html);
            Console.WriteLine("Html page successfully created");
            //Kreiranje slike sa pie-chartom prikaza podataka o vremenu radnika
            string pngPath = "C:\\Users\\User\\Desktop\\Priprema\\RareCrewApplication\\pie.png";
            pie.GeneratePieChart(employees1, pngPath);
            Console.WriteLine("Pie image successfully created");

            Console.ReadLine();

            




        }
        
        
    }
}







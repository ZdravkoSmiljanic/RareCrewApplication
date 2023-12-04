using Newtonsoft.Json;
using RareCrewApplication.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RareCrewApplication.Contollers
{
    public  class EmpolyeeController
    {
        public async Task<List<TotalWorkTime>> GetEmployeeData()
        {
            using (HttpClient client = new HttpClient())
            {
                
                string apiUrl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(jsonContent);
                    List<TotalWorkTime> emp;
                    //dohvatanje svakog usera, grupisanje i racunjanje ukupnog vremena provednog na poslu
                    emp = employees.GroupBy(entry => entry.EmployeeName).Select(group => new TotalWorkTime
                    {
                        EmployeeName = group.Key,
                        TotalWorkHours = group.Sum(entry => (entry.EndTimeUtc - entry.StarTimeUtc).TotalHours)
                    }).ToList();
                    //sortiranje prema vremenu
                    emp.Sort((a, b) => (b.TotalWorkHours).CompareTo(a.TotalWorkHours));
                    return emp;
                }
                else
                {
                    throw new Exception($"Error retrieving data. Status code: {response.StatusCode}");
                }
            }
        }
    }
}

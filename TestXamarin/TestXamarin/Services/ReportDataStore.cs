using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXamarin.Models;

namespace TestXamarin.Services
{
    //TODO Реализовать стркутуру данных репортов, как пример можно рассмотреть MockDataStore.cs
    class ReportDataStore : IDataStore<Report>
    {
        readonly List<Report> reports;

        public ReportDataStore()
        {
            //После создание БД лист должен заполняться инфой полученной с сервера
            reports = new List<Report>() 
            {
                new Report{ Id = Guid.NewGuid().ToString(), Text = "First report", Description = "driver's daun", NumberCar = "А327УЕ" },
                new Report{ Id = Guid.NewGuid().ToString(), Text = "Second report", Description = "driver's daun", NumberCar = "А632УЕ" }
            };
        }
        public async Task<bool> AddItemAsync(Report item)
        {
            reports.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = reports.Where((Report arg) => arg.Id == id).FirstOrDefault();
            reports.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Report> GetItemAsync(string id)
        {
            return await Task.FromResult(reports.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Report>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(reports);
        }

        public async Task<bool> UpdateItemAsync(Report item)
        {
            var oldItem = reports.Where(arg => arg.Id == item.Id).FirstOrDefault();
            reports.Remove(oldItem);
            reports.Add(item);

            return await Task.FromResult(true);
        }
    }
}

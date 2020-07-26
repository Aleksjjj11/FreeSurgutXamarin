using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestXamarin.Models;

namespace TestXamarin.Services
{
    //TODO Реализовать стркутуру данных репортов, как пример можно рассмотреть MockDataStore.cs
    class ReportDataStore : IDataStore<Report>
    {
        public Task<bool> AddItemAsync(Report item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Report> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Report>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Report item)
        {
            throw new NotImplementedException();
        }
    }
}

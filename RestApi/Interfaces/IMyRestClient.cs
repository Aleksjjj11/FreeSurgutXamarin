using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace RestApi.Interfaces
{
    public interface IMyRestClient
    {
        IRestResponse Registration(Dictionary<string,string> dataDictionary);
        IRestResponse Login(Dictionary<string,string> dataDictionary);
        IRestResponse UpdateRequest(Dictionary<string, string> dataDictionary);
        IRestResponse SendReportRequest(Dictionary<string, string> dataDictionary);
        IRestResponse GetReports(Dictionary<string, string> dataDictionary);
    }
}

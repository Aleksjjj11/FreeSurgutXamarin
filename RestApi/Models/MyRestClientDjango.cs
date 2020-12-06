using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestApi.Interfaces;
using RestSharp;

namespace RestApi
{
    public class MyRestClientDjango : IMyRestClient
    {
        private readonly string _ipServer;

        public MyRestClientDjango(string ipServer)
        {
            this._ipServer = ipServer;
        }

        public IRestResponse Registration(Dictionary<string, string> dataDictionary)
        {
            //http://188.225.83.42:8080/registration/
            var client = new RestClient($"http://{_ipServer}/registration/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("name", dataDictionary["Username"]);
            request.AddParameter("real_name", dataDictionary["RealName"]);
            request.AddParameter("password", dataDictionary["Password"]);
            request.AddParameter("email", dataDictionary["Email"]);
            request.AddParameter("send_report", "0");
            request.AddParameter("decline_report", "0");
            request.AddParameter("proccessing_report", "0");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse Login(Dictionary<string, string> dataDictionary)
        {
            var client = new RestClient($"http://{_ipServer}/login/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("name", dataDictionary["Username"]);
            request.AddParameter("password", dataDictionary["Password"]);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse UpdateRequest(Dictionary<string, string> dataDictionary)
        {
            throw new NotImplementedException();
        }

        public IRestResponse SendReportRequest(Dictionary<string, string> dataDictionary)
        {
            throw new NotImplementedException();
        }

        public IRestResponse GetReports(Dictionary<string, string> dataDictionary)
        {
            throw new NotImplementedException();
        }
    }
}

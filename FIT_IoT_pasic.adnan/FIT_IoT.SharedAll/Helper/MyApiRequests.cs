﻿using System.Net;
using Newtonsoft.Json;

namespace FIT_IoT.SharedAll.Helper
{
    public class MyApiRequests
    {
        public class P
        {
            public string _name;
            public object _value;

            public P(string name, object value)
            {
                _name = name;
                _value = value;
            }
        }
        public static ApiResult<T> Get<T>(string controllerName, string get, params P[] ps)
        {
            WebClient wc = new WebClient();
            string address = MyConfig.ServerUrl + "/"+ controllerName + "/" + get+"?";

            foreach (P p in ps)
            {
                address += p._name + "=" + p._value + "&";
            }
            string json = wc.DownloadString(address);
            ApiResult<T> result = JsonConvert.DeserializeObject<ApiResult<T>>(json);
            return result;
        }
    }
}
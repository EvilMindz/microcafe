using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MicroServices.Common.General.Util
{
    public class ApiClient
    {
        public T Load<T>(string url)
        {
            var client  = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));

            var response = client.GetStringAsync(url).Result;

            T result = default(T);
            result = JsonConvert.DeserializeObject<T>(response);

            return result;
        }

        public IList<T> LoadMany<T>(string url)
        {
            return Load<List<T>>(url);
        }

    }
}

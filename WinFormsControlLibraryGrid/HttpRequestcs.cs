using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WinFormsControlLibraryGrid
{
    internal class HttpRequest
    {
        public static string LocalUrl = "http://localhost:8081/";

        public static string GetRawDataList()
        {
            string result = string.Empty;

            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                result = client.DownloadString("http://localhost:8081/getRawDataList");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()); //통신 실패
            }
            return result;
        }

        public static string GetChartDataList()
        {
            string result = string.Empty;

            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                result = client.DownloadString("http://localhost:8081/GetChartDataList");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()); //통신 실패
            }
            return result;
        }

        public static string GetAlgoDictionary(String modelName, String modelVersion)
        {
            string result = string.Empty;

            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                //parameter 따옴표 필수
                Dictionary<String, Object> algorithms = new Dictionary<String, Object>();
                algorithms.Add("modelName", modelName);
                algorithms.Add("modelVersion", modelVersion);
                string url = makeRequestUrl(algorithms, "getAlgoDictionary");
                result = client.DownloadString(url);
  
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()); //통신 실패
            }
            return result;
        }


        public static List<T> LocalGetRequest<T>(string requestUrl)
        {
            string strResult;
            HttpWebRequest request = (HttpWebRequest)WebRequest
        .Create(LocalUrl + requestUrl);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using(StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
               strResult = reader.ReadToEnd();
            }
            List<T> ObjList = JsonConvert.DeserializeObject<List<T>>(strResult);

            return ObjList;
        }

        public static List<T> LocalGetRequest<T>(string requestUrl, Dictionary<string, object> paramMap)
        {
            string strResult;
            string url = makeRequestUrl(paramMap, requestUrl);

            HttpWebRequest request = (HttpWebRequest)WebRequest
        .Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                strResult = reader.ReadToEnd();
            }
            List<T> ObjList = JsonConvert.DeserializeObject<List<T>>(strResult);

            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            return ObjList;
        }

        private static string makeRequestUrl(Dictionary<string, object> algorithms, string requestUrl)
        {
            string url = "";
            url = LocalUrl + requestUrl + "?";
            int i = 0;

            foreach (KeyValuePair<string, object> pair in algorithms)
            {
                url += pair.Key + "=" + pair.Value;
                if (algorithms.Count != i)
                {
                    url += "&";
                }
                i++;
            }

            return url;
        }
    }
}
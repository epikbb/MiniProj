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
        private static readonly string LocalUrl = "http://localhost:8081/";

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

            HttpWebRequest request = (HttpWebRequest)WebRequest
        .Create(LocalUrl + requestUrl);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.UTF8);

            string strResult = srReadData.ReadToEnd();
            List<T> ObjList = JsonConvert.DeserializeObject<List<T>>(strResult);

            return ObjList;
        }

        public static List<T> LocalGetRequest<T>(string requestUrl, Dictionary<string, object> paramMap)
        {
            string url = makeRequestUrl(paramMap, requestUrl);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.UTF8);

            string strResult = srReadData.ReadToEnd();
            List<T> ObjList = JsonConvert.DeserializeObject<List<T>>(strResult);

            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            return ObjList;
        }

        private static string makeRequestUrl(Dictionary<string, object> paramMap, string requestUrl)
        {
            string url = "";
            url = LocalUrl + requestUrl + "?";
            int i = 0;

            foreach (KeyValuePair<string, object> pair in paramMap)
            {
                url += pair.Key + "=" + pair.Value;
                if (paramMap.Count != i)
                {
                    url += "&";
                }
                i++;
            }

            return url;
        }
    }
}
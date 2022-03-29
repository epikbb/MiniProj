using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;


namespace WinFormsControlLibraryGrid
{
    internal class HttpRequest
    {
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
                result = client.DownloadString("http://localhost:8081/getAlgoDictionary?modelName='" + modelName + "'&&modelVersion='" + modelVersion + "'");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()); //통신 실패
            }
            return result;
        }
    }
}
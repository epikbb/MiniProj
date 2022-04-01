using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace WinFormsControlLibraryGrid
{
    public partial class UserControl3 : UserControl
    {
        public string ModelName { get; set; }
        public string ModelVersion { get; set; }
        public AlgorithmDictionary AlgorithmDictionary { get; set; }

        public UserControl3()
        {
            InitializeComponent();

        }
        public static void Main()
        {
            UserControl3 u3 = new UserControl3();
            Console.WriteLine(u3);
            Console.ReadLine();
        }
        public void test(string Name, string Version)
        {
            MessageBox.Show(Name + Version);
        }
        public void RenderAlgo(string Name, string Version)
        {

            Dictionary<String, Object> algorithms = new Dictionary<String, Object>();
            algorithms.Add("modelName", Name);
            algorithms.Add("modelVersion", Version);
            HttpRequest.LocalGetRequest<AlgorithmDictionary>("getAlgoDictionary", algorithms);
            string dataList = HttpRequest.GetAlgoDictionary(ModelName, ModelVersion);
            Console.WriteLine(dataList);

            try
            {
                AlgorithmDictionary = JsonConvert.DeserializeObject<AlgorithmDictionary>(dataList, new JsonSerializerSettings());

                if (AlgorithmDictionary == null)
                {
                    AlgorithmDictionary = new AlgorithmDictionary
                    {
                        algoName = "null",
                        propName = "null",
                        propValue = 0
                    };
                }

                propertyGridControl1.SelectedObject = AlgorithmDictionary;
                //AlgorithmDictionary.algoName = ((AlgorithmDictionary)propertyGridControl1.SelectedObject).algoName;
                //AlgorithmDictionary.propName = ((AlgorithmDictionary)propertyGridControl1.SelectedObject).propName;
                //AlgorithmDictionary.propValue = ((AlgorithmDictionary)propertyGridControl1.SelectedObject).propValue;
                //var serializedStr = JsonConvert.SerializeObject(AlgorithmDictionary, Formatting.Indented);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void SetModelNameAndVersion(string Name, string Version)
        {
            this.ModelName = Name;
            this.ModelVersion = Version;
        }

       
        public class AlgoDto
        {
            public string modelName { get; set; }
            public string modelVersion { get; set; }
        }
    }
}
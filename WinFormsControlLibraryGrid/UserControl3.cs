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

namespace WinFormsControlLibraryGrid
{
    public partial class UserControl3 : UserControl
    {
        public AlgorithmDictionary AlgorithmDictionary { get; set; }  
        
        public UserControl3()
        {
            InitializeComponent();
            //모델탭에서 알고리즘이름 받아오게 수정해야함 (임시 ALGO_sample1)
            string dataList = HttpRequest.GetAlgoDictionary("ALGO_sample2");
            Console.WriteLine(dataList);

            try
            {
                AlgorithmDictionary = JsonConvert.DeserializeObject<AlgorithmDictionary>(dataList, new JsonSerializerSettings());

                if(AlgorithmDictionary == null)
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
        public static void Main()
        {
            UserControl3 u3 = new UserControl3();
            Console.WriteLine(u3);
            Console.ReadLine();
        }
    }
}

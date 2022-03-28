using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsControlLibraryGrid
{
    [DefaultProperty("algoName")]
    public class AlgorithmDictionary
    {
        private string _algoName;
        private string _propName;
        private float _propValue;

        [Category("Predict")]
        public string algoName { get; set; }
        [Category("Predict")]
        public string propName { get; set; }
        [Category("Predict")]
        public float propValue { get; set; }

    }
}

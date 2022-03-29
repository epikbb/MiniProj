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
        [Category("Predict")]
        public string algoName { get; set; }
        [Category("Predict")]
        public string propName { get; set; }
        [Category("Predict")]
        public float propValue { get; set; }

    }
}

using DevExpress.Utils;
using DevExpress.XtraCharts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControlLibraryGrid
{
    public partial class UserControl22 : UserControl
    {
        public bool ongoing;
        private int _i = 0;
        private double _ucl = 0;
        private double _lcl = 0;
        private Series[] _series;
        private List<RawData> _datas;
        private XYDiagram _diagram;

        public UserControl22()
        {
            InitializeComponent();
            _series = new Series[4];
            _series[0] = new Series("Actual Value", ViewType.Line);
            _series[1] = new Series("Predict Value", ViewType.Line);
            _series[2] = new Series("UCL", ViewType.Line);
            _series[3] = new Series("LCL", ViewType.Line);
            ongoing = true;
        }

        public void ChartWrite()
        {
            //string dataList = HttpRequest.GetRawDataList();
            List<RawData> _datas = HttpRequest.LocalGetRequest<RawData>("getRawDataList");
            //_datas = JsonConvert.DeserializeObject<List<RawData>>(dataList);


            double sum = 0;
            double sum2 = 0;

            List<double> actList = new List<double>();
            for (int i = 0; i < _datas.Count; i++)
            {
                sum += _datas[i].actVal;
                sum2 += _datas[i].accuracy;
                actList.Add(_datas[i].actVal);

            }
            double actAvg = sum / _datas.Count;
            double accuracy = sum2 / _datas.Count;
            _ucl = actAvg + (getStandardDeviation(actList) * 3);
            _lcl = actAvg - (getStandardDeviation(actList) * 3);
            Console.WriteLine("ucl" + _ucl);
            Console.WriteLine("lcl" + _lcl);

            _series[0].View.Color = Color.Red;
            _series[1].View.Color = Color.Green;
            _series[2].View.Color = Color.Navy;
            _series[3].View.Color = Color.Purple;

            _series[0].ArgumentScaleType = ScaleType.DateTime;
            _series[1].ArgumentScaleType = ScaleType.DateTime;
            _series[2].ArgumentScaleType = ScaleType.DateTime;
            _series[3].ArgumentScaleType = ScaleType.DateTime;

            chartControl1.Series.Add(_series[0]);
            chartControl1.Series.Add(_series[1]);
            chartControl1.Series.Add(_series[2]);
            chartControl1.Series.Add(_series[3]);

            (chartControl1.Series[0].View as LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;  // 마크 표시
            (chartControl1.Series[1].View as LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;  // 마크 표시

            ((LineSeriesView)chartControl1.Series[0].View).LineMarkerOptions.Size = 4;
            ((LineSeriesView)chartControl1.Series[1].View).LineMarkerOptions.Size = 4;
            ((LineSeriesView)chartControl1.Series[2].View).LineMarkerOptions.Size = 4;
            ((LineSeriesView)chartControl1.Series[3].View).LineMarkerOptions.Size = 4;

            ((LineSeriesView)chartControl1.Series[0].View).LineStyle.Thickness = 1;
            ((LineSeriesView)chartControl1.Series[1].View).LineStyle.Thickness = 1;
            ((LineSeriesView)chartControl1.Series[2].View).LineStyle.Thickness = 1;
            ((LineSeriesView)chartControl1.Series[3].View).LineStyle.Thickness = 1;

            _diagram = (XYDiagram)chartControl1.Diagram;
            _diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Second;

            _diagram.AxisY.NumericScaleOptions.AutoGrid = false;
 //           _diagram.AxisY.NumericScaleOptions.GridAlignment = NumericGridAlignment.Custom;
 //           _diagram.AxisY.NumericScaleOptions.CustomGridAlignment = 0.0001;       
 //           _diagram.AxisY.NumericScaleOptions.GridOffset = 2;

            Legend legend = chartControl1.Legend;
            legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            legend.Direction = LegendDirection.LeftToRight;

            legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            legend.Margins.Top = 30;

            _series[0].ShowInLegend = true;
            _series[1].ShowInLegend = true;

            // Create chart titles.
            ChartTitle chartTitle1 = new ChartTitle();
            ChartTitle chartTitle2 = new ChartTitle();

            chartTitle1.Text = "Simulation Model Result";
            chartTitle2.Text = "Accuracy Avg : " + Math.Round(accuracy, 2) + "%";

            chartTitle1.Alignment = StringAlignment.Center;
            chartTitle2.Alignment = StringAlignment.Center;

            chartTitle1.Font = new Font("Tahoma", 10, FontStyle.Regular);
            chartTitle2.Font = new Font("Tahoma", 9, FontStyle.Regular);
            chartTitle1.TextColor = Color.Black;
            chartTitle2.TextColor = Color.Black;

            chartControl1.Titles.AddRange(new ChartTitle[] { chartTitle1, chartTitle2 });

            timer1.Interval = 50;     
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            //return dataList;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {  
            if (ongoing)
            {
                if (_series[0].Points.Count > 30)
                {
                    timer1.Interval = 150;
                    _series[0].Points.RemoveAt(0);
                    _series[1].Points.RemoveAt(0);
                    _series[2].Points.RemoveAt(0);
                    _series[3].Points.RemoveAt(0);
                }

                try
                {
                    _series[0].Points.Add(new SeriesPoint(_datas[_i].mesureDtTm, _datas[_i].actVal));
                    _series[1].Points.Add(new SeriesPoint(_datas[_i].mesureDtTm, _datas[_i].predVal));
                    _series[2].Points.Add(new SeriesPoint(_datas[_i].mesureDtTm, _ucl));
                    _series[3].Points.Add(new SeriesPoint(_datas[_i].mesureDtTm, _lcl));
                }
                catch (Exception)
                {
                    timer1.Stop();
                    MessageBox.Show("더이상의 측정 데이터가 없습니다!");
                }

                _diagram.AxisY.WholeRange.SetMinMaxValues(_lcl, _ucl);
                _diagram.AxisX.Label.TextPattern = "{ A: mm:ss}";
                _diagram.AxisX.WholeRange.SideMarginsValue = 0;
                _diagram.AxisY.GridLines.Visible = false;

                _i++;
            }
        }

        //표준편차
        private double getStandardDeviation(List<double> doubleList)
        {
            double average = doubleList.Average();
            double sumOfDerivation = 0;
            foreach (double value in doubleList)
            {
                sumOfDerivation += (value) * (value);
            }
            double sumOfDerivationAverage = sumOfDerivation / doubleList.Count;
            return Math.Sqrt(sumOfDerivationAverage - (average * average));
        }

    }
}



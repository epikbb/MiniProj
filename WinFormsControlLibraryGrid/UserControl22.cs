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
        int i = 0;
        double ucl = 0;
        double lcl = 0;
        Series[] series;
        List<RawData> datas;
        XYDiagram diagram;
        public bool ongoing;
        //public event Form1.ClickMe CustomControlClickMe;



        public UserControl22()
        {
            InitializeComponent();
            series = new Series[4];
            series[0] = new Series("Actual Value", ViewType.Line);
            series[1] = new Series("Predict Value", ViewType.Line);
            series[2] = new Series("UCL", ViewType.Line);
            series[3] = new Series("LCL", ViewType.Line);
            ChartWrite();
        }


        public string ChartWrite()
        {
            ongoing = true;

            string dataList = HttpRequest.GetRawDataList();
            datas = JsonConvert.DeserializeObject<List<RawData>>(dataList);

            double sum = 0;
            double sum2 = 0;

            List<double> actList = new List<double>();
            for (int i = 0; i < datas.Count; i++)
            {
                sum += datas[i].actVal;
                sum2 += datas[i].accuracy;
                actList.Add(datas[i].actVal);

            }
            double actAvg = sum / datas.Count;
            double accuracy = sum2 / datas.Count;
            ucl = actAvg + (getStandardDeviation(actList) * 3);
            lcl = actAvg - (getStandardDeviation(actList) * 3);
            Console.WriteLine("ucl" + ucl);
            Console.WriteLine("lcl" + lcl);


            series[0].View.Color = Color.Red;
            series[1].View.Color = Color.Green;
            series[2].View.Color = Color.Navy;
            series[3].View.Color = Color.Navy;

            series[0].ArgumentScaleType = ScaleType.DateTime;
            series[1].ArgumentScaleType = ScaleType.DateTime;
            series[2].ArgumentScaleType = ScaleType.DateTime;
            series[3].ArgumentScaleType = ScaleType.DateTime;

            chartControl1.Series.Add(series[0]);
            chartControl1.Series.Add(series[1]);
            chartControl1.Series.Add(series[2]);
            chartControl1.Series.Add(series[3]);


            (chartControl1.Series[0].View as LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;  // 마크 표시
            (chartControl1.Series[1].View as LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;  // 마크 표시


            ((LineSeriesView)this.chartControl1.Series[0].View).LineMarkerOptions.Size = 4;
            ((LineSeriesView)this.chartControl1.Series[1].View).LineMarkerOptions.Size = 4;
            ((LineSeriesView)this.chartControl1.Series[2].View).LineMarkerOptions.Size = 4;
            ((LineSeriesView)this.chartControl1.Series[3].View).LineMarkerOptions.Size = 4;


            ((LineSeriesView)chartControl1.Series[0].View).LineStyle.Thickness = 1;
            ((LineSeriesView)chartControl1.Series[1].View).LineStyle.Thickness = 1;
            ((LineSeriesView)chartControl1.Series[2].View).LineStyle.Thickness = 1;
            ((LineSeriesView)chartControl1.Series[3].View).LineStyle.Thickness = 1;


            diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Second;

            diagram.AxisY.NumericScaleOptions.AutoGrid = true;

            Legend legend = chartControl1.Legend;
            legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            legend.Direction = LegendDirection.LeftToRight;

            legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            legend.Margins.Top = 30;

            series[0].ShowInLegend = true;
            series[1].ShowInLegend = true;

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


            timer1.Interval = 300;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            return dataList;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            if (ongoing)
            {
                if (series[0].Points.Count > 30)
                {
                    series[0].Points.RemoveAt(0);
                    series[1].Points.RemoveAt(0);
                    series[2].Points.RemoveAt(0);
                    series[3].Points.RemoveAt(0);
                }

                try
                {
                    series[0].Points.Add(new SeriesPoint(datas[i].mesureDtTm, datas[i].actVal));
                    series[1].Points.Add(new SeriesPoint(datas[i].mesureDtTm, datas[i].predVal));
                    series[2].Points.Add(new SeriesPoint(datas[i].mesureDtTm, ucl));
                    series[3].Points.Add(new SeriesPoint(datas[i].mesureDtTm, lcl));
                }
                catch (Exception)
                {
                    timer1.Stop();
                    MessageBox.Show("fin!");
                }

                diagram.AxisY.WholeRange.SetMinMaxValues(lcl, ucl);
                diagram.AxisX.Label.TextPattern = "{ A: mm:ss}";
                diagram.AxisX.WholeRange.SideMarginsValue = 0;
                diagram.AxisY.GridLines.Visible = false;

                i++;
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


